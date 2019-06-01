using AutoMapper;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using UMA.App.IdentityManager.Authentication.Models;
using UMA.App.IdentityManager.Authentication.Queries;
using UMA.App.IdentityManager.Identity.Queries;
using UMA.Persistence.Identity.Context;

namespace UMA.App.IdentityManager.Authentication.Handlers
{
    public class RegisterUserQueryHandler : IdentityManagerBaseHandler<RegisterUserQuery, RegisterUserResult>
    {
        private IMediator _mediator;

        public RegisterUserQueryHandler(IdentityDbContext context, IMapper mapper, IMediator mediator) : base(context, mapper)
        {
            _mediator = mediator;
        }

        public async override Task<RegisterUserResult> Handle(RegisterUserQuery request, CancellationToken cancellationToken)
        {
            var response = new RegisterUserResult();

            try
            {
                    var create_response = await _mediator.Send(new CreateIdentityQuery
                    {
                        Login = request.Login,
                        Password = request.Password
                    });

                    if (create_response.Result)
                    {
                        var auth_response = await _mediator.Send(new AuthenticateUserQuery { Login = request.Login, Password = request.Password });
                        if (auth_response.Result)
                        {
                            response = _mapper.Map<RegisterUserResult>(auth_response);
                        }
                        else
                        {
                            response.Result = false;
                            response.Message = auth_response.Message;
                        }
                    }
                    else
                    {
                        response.Result = false;
                        response.Message = create_response.Message;
                    }
            }
            catch (Exception e)
            {
                HandleException(response, e);
            }

            return response;
        }
    }
}
