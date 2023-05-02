using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Practice.API.Common;
using Practice.API.DbContexts;
using WebApplication1.Entities;
using Practice.API.Model;
using Practice.API.Profiles;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using WebApplication1.Entities;

namespace Practice.API.Services
{
    public class UserService : IUserService
    {
        private readonly InfoContext infoContext;
        private readonly IMapper mapper;
        private readonly IConfiguration configuration;

        public UserService(InfoContext infoContext,IMapper mapper,IConfiguration configuration)
        {
            this.infoContext = infoContext ?? throw new ArgumentNullException(nameof(infoContext));
            this.mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            this.configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));
        }
        public async Task CreateUser(UserDto userDto)
        {
            if(userDto != null)
            {
                var EncPassword = CommonMethod.ConvertToEncrypt(userDto.Password);
                userDto.Password = EncPassword;
                await infoContext.User.AddAsync(mapper.Map<Users>(userDto));
            }
            
        }

        public async Task<UserDto> GetSingleUser(string email)
        {
            var ExistUser=await infoContext.User.FirstOrDefaultAsync<Users>(s=>s.Email==email);
            return mapper.Map<UserDto>(ExistUser);
        }

        public async Task<string> LoginUser(string email, string password)
        {
            if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password))
            {
                return "Email and password are required.";
            }

            UserDto ExistUser = await GetSingleUser(email);
            if (ExistUser != null)
            {
                var DecodePassword = CommonMethod.ConvertToDecrypt(ExistUser.Password);
                if (DecodePassword == password)
                {
                    try
                    {
                        var securityKey = new SymmetricSecurityKey(System.Text.Encoding.ASCII.GetBytes(configuration["Authentication:SecretForKey"]));

                        var signingCredentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

                        var claimsForToken = new List<Claim>();
                        claimsForToken.Add(new Claim("sub", ExistUser.Email));
                        claimsForToken.Add(new Claim("given_name",ExistUser.Password));
                        claimsForToken.Add(new Claim("user_role",ExistUser.userRoles.ToString()));

                        var jwtSecurityToken = new JwtSecurityToken(
                           configuration["Authentication:Issuer"],
                           configuration["Authentication:Audience"],
                           claimsForToken,
                           DateTime.UtcNow,
                           DateTime.UtcNow.AddHours(1),
                           signingCredentials);

                        var tokenReturn = new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken);

                        return tokenReturn;
                    }
                    catch (Exception ex)
                    {
                        return  "An error occurred while generating the JWT token.";
                    }
                }
            }

            return "Invalid email or password.";
        }


        public async Task<bool> SaveChangesAsync()
        {
            return (await infoContext.SaveChangesAsync() > 0);
        }
		public async Task<IEnumerable<Users>> GetAllUsers()
        {
			return await infoContext.User.ToListAsync();
		}

	}
}
