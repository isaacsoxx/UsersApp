using AutoMapper;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using UsersApp.BLL.Services.Interface;
using UsersApp.DAL.Repository.Interface;
using UsersApp.DTOs.Model;

namespace UsersApp.BLL.Services
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly IUserRepository _repository;
        private readonly IMapper _mapper;
        private readonly IConfiguration _configuration;

        public AuthenticationService(IUserRepository repository, IMapper mapper, IConfiguration configuration)
        {
            _repository = repository;
            _mapper = mapper;
            _configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));
        }

        public async Task<ServiceResponseDTO<string>> ValidateCredentials(string emailAddress, string password)
        {
            var serviceResponse = new ServiceResponseDTO<string>();
            var authenticatedUser = await _repository.ValidateUserAsync(emailAddress, password);

            if (authenticatedUser != null)
            {
                var securityKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(_configuration["Authentication:SecretForKey"]));
                var signingCredentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
                var claimsForToken = new List<Claim>();
                claimsForToken.Add(new Claim("sub", authenticatedUser.UserId.ToString()));
                claimsForToken.Add(new Claim("email_address", authenticatedUser.Email));

                var jwtSecurityToken = new JwtSecurityToken(
                    _configuration["Authentication:Issuer"],
                    _configuration["Authentication:Audience"],
                    claimsForToken,
                    DateTime.UtcNow,
                    DateTime.UtcNow.AddHours(1),
                    signingCredentials
                );
                serviceResponse.Data = new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken);
            }
            else
            {
                serviceResponse.Error = true;
                serviceResponse.Message = $"Account {emailAddress} couldn't be authenticated!";
            }

            return serviceResponse;
        }

    }
}
