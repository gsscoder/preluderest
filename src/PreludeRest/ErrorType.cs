namespace PreludeRest
{
    public static class ErrorType
    {
        public const string Error400BadRequest =
            "https://datatracker.ietf.org/doc/html/rfc7231#section-6.5.1";
        public const string Error401Unauthorized =
            "https://datatracker.ietf.org/doc/html/rfc7235#section-3.1";
        public const string Error404NotFound =
            "https://datatracker.ietf.org/doc/html/rfc7231#section-6.5.4";
        public const string Error500InternalServerError =
            "https://datatracker.ietf.org/doc/html/rfc7231#section-6.6.1";
    }
}
