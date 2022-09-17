namespace IdentityServer.Models
{
    public class ErrorViewModel
    {
        /// <summary>
        /// Request Id
        /// </summary>
        public string RequestId { get; set; }

        /// <summary>
        /// ShowRequestId
        /// </summary>
        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);
    }
}
