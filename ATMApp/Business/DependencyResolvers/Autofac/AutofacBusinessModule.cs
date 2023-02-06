using Autofac;
using Business.Abstract;
using Business.Concrete;
using Core.Utilities.Security.Jwt;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.EntityFramework.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.DependencyResolvers.Autofac
{
    public class AutofacBusinessModule:Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            // Register edilen tipi veriyoruz. ICustomerService isteyen constructorda ona CustomerManager ver. Controller için
            builder.RegisterType<CustomerManager>().As<ICustomerService>();
            // Business Katmanı  için CTOR'da Dependency Injection modeli ile parametrede istenildiğinde gönderdiğimiz değer.
            builder.RegisterType<EfCustomerDal>().As<ICustomerDal>();

            builder.RegisterType<TransactionManager>().As<ITransactionService>();
            builder.RegisterType<EfTransactionDal>().As<ITransactionDal>();

            // Contructar'da IUserService isteyene UserManager veriyor.
            builder.RegisterType<UserManager>().As<IUserService>();
            builder.RegisterType<EfUserDal>().As<IUserDal>();
            
            builder.RegisterType<AuthManager>().As<IAuthService>();
            builder.RegisterType<JwtHelper>().As<ITokenHelper>();

            builder.RegisterType<EmailManager>().As<IEmailService>();
        }
    }
}
