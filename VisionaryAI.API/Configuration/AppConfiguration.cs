namespace VisionaryAI.API.Configuration
{
    public class AppConfiguration
    {
        public SwaggerDoc Swagger { get; set; }

        public ConnectionString ConnectionStrings { get; set; }

        public class ConnectionString
        {
            public string OracleVisionaryAI { get; set; }
        }

        public class SwaggerDoc
        {
            public string Title { get; set; }
            public string Description { get; set; }
        }
    }
}
