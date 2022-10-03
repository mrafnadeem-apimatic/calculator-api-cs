// <copyright file="SimpleCalculatorController.cs" company="APIMatic">
// Copyright (c) APIMatic. All rights reserved.
// </copyright>
namespace APIMATICCalculator.Standard.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Dynamic;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Threading;
    using System.Threading.Tasks;
    using APIMATICCalculator.Standard;
    using APIMATICCalculator.Standard.Authentication;
    using APIMATICCalculator.Standard.Http.Client;
    using APIMATICCalculator.Standard.Http.Request;
    using APIMATICCalculator.Standard.Http.Request.Configuration;
    using APIMATICCalculator.Standard.Http.Response;
    using APIMATICCalculator.Standard.Utilities;
    using Newtonsoft.Json.Converters;

    /// <summary>
    /// SimpleCalculatorController.
    /// </summary>
    public class SimpleCalculatorController : BaseController
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SimpleCalculatorController"/> class.
        /// </summary>
        /// <param name="config"> config instance. </param>
        /// <param name="httpClient"> httpClient. </param>
        /// <param name="authManagers"> authManager. </param>
        /// <param name="httpCallBack"> httpCallBack. </param>
        internal SimpleCalculatorController(IConfiguration config, IHttpClient httpClient, IDictionary<string, IAuthManager> authManagers, HttpCallBack httpCallBack = null)
            : base(config, httpClient, authManagers, httpCallBack)
        {
        }

        /// <summary>
        /// Calculates the expression using the specified operation.
        /// </summary>
        /// <param name="input">Object containing request parameters.</param>
        /// <returns>Returns the double response from the API call.</returns>
        public double GetCalculate(
                Models.GetCalculateInput input)
        {
            Task<double> t = this.GetCalculateAsync(input);
            ApiHelper.RunTaskSynchronously(t);
            return t.Result;
        }

        /// <summary>
        /// Calculates the expression using the specified operation.
        /// </summary>
        /// <param name="input">Object containing request parameters.</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the double response from the API call.</returns>
        public async Task<double> GetCalculateAsync(
                Models.GetCalculateInput input,
                CancellationToken cancellationToken = default)
        {
            // the base uri for api requests.
            string baseUri = this.Config.GetBaseUri();

            // prepare query string for API call.
            StringBuilder queryBuilder = new StringBuilder(baseUri);
            queryBuilder.Append("/{operation}");

            // process optional template parameters.
            ApiHelper.AppendUrlWithTemplateParameters(queryBuilder, new Dictionary<string, object>()
            {
                { "operation", ApiHelper.JsonSerialize(input.Operation).Trim('\"') },
            });

            // prepare specfied query parameters.
            var queryParams = new Dictionary<string, object>()
            {
                { "x", input.X },
                { "y", input.Y },
            };

            // append request with appropriate headers and parameters
            var headers = new Dictionary<string, string>()
            {
                { "user-agent", this.UserAgent },
            };

            // prepare the API call request to fetch the response.
            HttpRequest httpRequest = this.GetClientInstance().Get(queryBuilder.ToString(), headers, queryParameters: queryParams);

            if (this.HttpCallBack != null)
            {
                this.HttpCallBack.OnBeforeHttpRequestEventHandler(this.GetClientInstance(), httpRequest);
            }

            // invoke request and get response.
            HttpStringResponse response = await this.GetClientInstance().ExecuteAsStringAsync(httpRequest, cancellationToken: cancellationToken).ConfigureAwait(false);
            HttpContext context = new HttpContext(httpRequest, response);
            if (this.HttpCallBack != null)
            {
                this.HttpCallBack.OnAfterHttpResponseEventHandler(this.GetClientInstance(), response);
            }

            // handle errors defined at the API level.
            this.ValidateResponse(response, context);

            return double.Parse(response.Body);
        }
    }
}