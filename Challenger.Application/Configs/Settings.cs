namespace Challenger.Application.Configs;

public class Settings
{
    public MongoDbSettings MongoDb { get; set; }
    
    public ConnectionSettings ConnectionStrings { get; set; }
    
    public SwaggerSettings Swagger { get; set; }
    public SwaggerSettings SwaggerV2 { get; set; }
}