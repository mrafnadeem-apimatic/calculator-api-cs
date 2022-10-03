// <copyright file="GetCalculateInput.cs" company="APIMatic">
// Copyright (c) APIMatic. All rights reserved.
// </copyright>
namespace APIMATICCalculator.Standard.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using APIMATICCalculator.Standard;
    using APIMATICCalculator.Standard.Utilities;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;

    /// <summary>
    /// GetCalculateInput.
    /// </summary>
    public class GetCalculateInput
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="GetCalculateInput"/> class.
        /// </summary>
        public GetCalculateInput()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="GetCalculateInput"/> class.
        /// </summary>
        /// <param name="operation">operation.</param>
        /// <param name="x">x.</param>
        /// <param name="y">y.</param>
        /// <param name="stringparam">stringparam.</param>
        /// <param name="dateparam">dateparam.</param>
        /// <param name="numparam">numparam.</param>
        /// <param name="objparam">objparam.</param>
        public GetCalculateInput(
            Models.OperationTypeEnum operation,
            double x,
            double y,
            string stringparam = null,
            DateTime? dateparam = null,
            int? numparam = null,
            object objparam = null)
        {
            this.Operation = operation;
            this.X = x;
            this.Y = y;
            this.Stringparam = stringparam;
            this.Dateparam = dateparam;
            this.Numparam = numparam;
            this.Objparam = objparam;
        }

        /// <summary>
        /// The operator to apply on the variables
        /// </summary>
        [JsonProperty("operation", ItemConverterType = typeof(StringEnumConverter))]
        public Models.OperationTypeEnum Operation { get; set; }

        /// <summary>
        /// The LHS value
        /// </summary>
        [JsonProperty("x")]
        public double X { get; set; }

        /// <summary>
        /// The RHS value
        /// </summary>
        [JsonProperty("y")]
        public double Y { get; set; }

        /// <summary>
        /// Gets or sets Stringparam.
        /// </summary>
        [JsonProperty("stringparam", NullValueHandling = NullValueHandling.Ignore)]
        public string Stringparam { get; set; }

        /// <summary>
        /// Gets or sets Dateparam.
        /// </summary>
        [JsonConverter(typeof(APIMATICCalculator.Standard.Utilities.UnixDateTimeConverter))]
        [JsonProperty("dateparam", NullValueHandling = NullValueHandling.Ignore)]
        public DateTime? Dateparam { get; set; }

        /// <summary>
        /// Gets or sets Numparam.
        /// </summary>
        [JsonProperty("numparam", NullValueHandling = NullValueHandling.Ignore)]
        public int? Numparam { get; set; }

        /// <summary>
        /// Gets or sets Objparam.
        /// </summary>
        [JsonProperty("objparam", NullValueHandling = NullValueHandling.Ignore)]
        public object Objparam { get; set; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"GetCalculateInput : ({string.Join(", ", toStringOutput)})";
        }

        /// <inheritdoc/>
        public override bool Equals(object obj)
        {
            if (obj == null)
            {
                return false;
            }

            if (obj == this)
            {
                return true;
            }

            return obj is GetCalculateInput other &&
                this.Operation.Equals(other.Operation) &&
                this.X.Equals(other.X) &&
                this.Y.Equals(other.Y) &&
                ((this.Stringparam == null && other.Stringparam == null) || (this.Stringparam?.Equals(other.Stringparam) == true)) &&
                ((this.Dateparam == null && other.Dateparam == null) || (this.Dateparam?.Equals(other.Dateparam) == true)) &&
                ((this.Numparam == null && other.Numparam == null) || (this.Numparam?.Equals(other.Numparam) == true)) &&
                ((this.Objparam == null && other.Objparam == null) || (this.Objparam?.Equals(other.Objparam) == true));
        }
        

        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.Operation = {this.Operation}");
            toStringOutput.Add($"this.X = {this.X}");
            toStringOutput.Add($"this.Y = {this.Y}");
            toStringOutput.Add($"this.Stringparam = {(this.Stringparam == null ? "null" : this.Stringparam == string.Empty ? "" : this.Stringparam)}");
            toStringOutput.Add($"this.Dateparam = {(this.Dateparam == null ? "null" : this.Dateparam.ToString())}");
            toStringOutput.Add($"this.Numparam = {(this.Numparam == null ? "null" : this.Numparam.ToString())}");
            toStringOutput.Add($"Objparam = {(this.Objparam == null ? "null" : this.Objparam.ToString())}");
        }
    }
}