using Serilog;
using Serilog.Events;
using Serilog.Sinks.MSSqlServer;
using System.Configuration;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http.ExceptionHandling;
using System.Web.Http.Results;

namespace SmartChef.Utility
{
    /// <summary>
    /// Exception Handler
    /// </summary>
    public class SmartChefExceptionHandlerFilter : ExceptionHandler
    {
        /// <inheritdoc />
        /// <summary>
        /// This method handles exception occurred in the api
        /// </summary>
        /// <param name="context"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public override async Task HandleAsync(ExceptionHandlerContext context, CancellationToken cancellationToken)
        {
            var  connectionString = ConfigurationManager.ConnectionStrings["SmartChecfDbContext"].ConnectionString;
            var tableName = ConfigurationManager.AppSettings["logTable"];

            var columnOption = new ColumnOptions();
            // columnOption.Store.Remove(StandardColumn.MessageTemplate);
            columnOption.Store.Remove(StandardColumn.Properties);

            Log.Logger = new LoggerConfiguration()
                            .MinimumLevel.Information()
                            .MinimumLevel.Override("SerilogDemo", LogEventLevel.Fatal)
                            .WriteTo.MSSqlServer(connectionString, tableName, columnOptions: columnOption)
                            .CreateLogger();

            Log.Logger.Error(context.Exception, context.Exception.Message);


            var response = context.Request.CreateResponse(HttpStatusCode.InternalServerError,
                new
                {
                    Message = "An error has Occured"
                });
            response.Headers.Add(Constants.AuthHeader, Constants.ErrorMessage);
            context.Result = new ResponseMessageResult(response);
        }
    }
}