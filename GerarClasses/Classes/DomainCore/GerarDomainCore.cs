namespace GerarClasses.Classes
{
    public static partial class GerarDomainCore
    {
        private static readonly string pathDomainCoreBusTemplate = @"Templates\DomainCore\";

        public static void DomainCore(Parametros param)
        {
            // CRIAR A PASTA BUS e seus itens;
            string template = LerTemplate.Ler(param.EnderecoDaPastaPadraoDoProgramaGerador, pathDomainCoreBusTemplate, @"Bus.IMediatorHandler.txt");
            template = template.Replace("{{Sistema}}", param.NomeDoSistema);
            GravarResultado.Gravar(false, template, "IMediatorHandler.cs", param.EnderecoDoProjetoDomainCore, @"Bus\");

            template = LerTemplate.Ler(param.EnderecoDaPastaPadraoDoProgramaGerador, pathDomainCoreBusTemplate, @"Bus.HandlerResult.txt");
            template = template.Replace("{{Sistema}}", param.NomeDoSistema);
            GravarResultado.Gravar(false, template, "HandlerResult.cs", param.EnderecoDoProjetoDomainCore, @"Bus\");


            // CRIAR A PASTA COMMANDS e seus itens;
            template = LerTemplate.Ler(param.EnderecoDaPastaPadraoDoProgramaGerador, pathDomainCoreBusTemplate, @"Commands.Command.txt");
            template = template.Replace("{{Sistema}}", param.NomeDoSistema);
            GravarResultado.Gravar(false, template, "Command.cs", param.EnderecoDoProjetoDomainCore, @"Commands\");

            template = LerTemplate.Ler(param.EnderecoDaPastaPadraoDoProgramaGerador, pathDomainCoreBusTemplate, @"Commands.CommandResponse.txt");
            template = template.Replace("{{Sistema}}", param.NomeDoSistema);
            GravarResultado.Gravar(false, template, "CommandResponse.cs", param.EnderecoDoProjetoDomainCore, @"Commands\");

            // CRIAR A PASTA EVENTS e seus itens;
            template = LerTemplate.Ler(param.EnderecoDaPastaPadraoDoProgramaGerador, pathDomainCoreBusTemplate, @"Events.Event.txt");
            template = template.Replace("{{Sistema}}", param.NomeDoSistema);
            GravarResultado.Gravar(false, template, "Event.cs", param.EnderecoDoProjetoDomainCore, @"Events\");

            template = LerTemplate.Ler(param.EnderecoDaPastaPadraoDoProgramaGerador, pathDomainCoreBusTemplate, @"Events.IEventStore.txt");
            template = template.Replace("{{Sistema}}", param.NomeDoSistema);
            GravarResultado.Gravar(false, template, "IEventStore.cs", param.EnderecoDoProjetoDomainCore, @"Events\");

            template = LerTemplate.Ler(param.EnderecoDaPastaPadraoDoProgramaGerador, pathDomainCoreBusTemplate, @"Events.IHandler.txt");
            template = template.Replace("{{Sistema}}", param.NomeDoSistema);
            GravarResultado.Gravar(false, template, "IHandler.cs", param.EnderecoDoProjetoDomainCore, @"Events\");

            template = LerTemplate.Ler(param.EnderecoDaPastaPadraoDoProgramaGerador, pathDomainCoreBusTemplate, @"Events.Message.txt");
            template = template.Replace("{{Sistema}}", param.NomeDoSistema);
            GravarResultado.Gravar(false, template, "Message.cs", param.EnderecoDoProjetoDomainCore, @"Events\");

            template = LerTemplate.Ler(param.EnderecoDaPastaPadraoDoProgramaGerador, pathDomainCoreBusTemplate, @"Events.StoredEvent.txt");
            template = template.Replace("{{Sistema}}", param.NomeDoSistema);
            GravarResultado.Gravar(false, template, "StoredEvent.cs", param.EnderecoDoProjetoDomainCore, @"Events\");

            // CRIAR A PASTA MODELS e seus itens;
            template = LerTemplate.Ler(param.EnderecoDaPastaPadraoDoProgramaGerador, pathDomainCoreBusTemplate, @"Models.Entity.txt");
            template = template.Replace("{{Sistema}}", param.NomeDoSistema);
            GravarResultado.Gravar(false, template, "Entity.cs", param.EnderecoDoProjetoDomainCore, @"Models\");

            template = LerTemplate.Ler(param.EnderecoDaPastaPadraoDoProgramaGerador, pathDomainCoreBusTemplate, @"Models.ValueObject.txt");
            template = template.Replace("{{Sistema}}", param.NomeDoSistema);
            GravarResultado.Gravar(false, template, "ValueObject.cs", param.EnderecoDoProjetoDomainCore, @"Models\");

            // CRIAR A PASTA NOTIFICATIONS e seus itens;
            template = LerTemplate.Ler(param.EnderecoDaPastaPadraoDoProgramaGerador, pathDomainCoreBusTemplate, @"Notifications.DomainNotification.txt");
            template = template.Replace("{{Sistema}}", param.NomeDoSistema);
            GravarResultado.Gravar(false, template, "DomainNotification.cs", param.EnderecoDoProjetoDomainCore, @"Notifications\");

            template = LerTemplate.Ler(param.EnderecoDaPastaPadraoDoProgramaGerador, pathDomainCoreBusTemplate, @"Notifications.DomainNotificationHandler.txt");
            template = template.Replace("{{Sistema}}", param.NomeDoSistema);
            GravarResultado.Gravar(false, template, "DomainNotificationHandler.cs", param.EnderecoDoProjetoDomainCore, @"Notifications\");

            // CRIAR O PROJETO DOMAIN.CORE
            template = LerTemplate.Ler(param.EnderecoDaPastaPadraoDoProgramaGerador, pathDomainCoreBusTemplate, @"Domain.Core.csproj.txt");
            GravarResultado.Gravar(false, template, $"{param.NomeDoSistema}.Domain.Core.csproj", param.EnderecoDoProjetoDomainCore);
        }

    }
}
