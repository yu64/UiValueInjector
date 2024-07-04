using System.Collections.Immutable;
using System.CommandLine;
using System.CommandLine.Invocation;
using System.CommandLine.NamingConventionBinder;
using System.Data;
using System.Text;
using UiValueInjector.Core;
using UiValueInjector.Domain;
using UiValueInjector.Usecase;

namespace UiValueInjector.Presentation;


public class ConsoleController
{   
    private readonly InjectUsecase usecase;
    private readonly IAppConnectorFactory connectorFactory;

    private readonly ConfigParser parser;
    private readonly RootCommand root;


    
    public ConsoleController(
        InjectUsecase usecase,
        IAppConnectorFactory connectorFactory,
        IElementSelectorFactory selectorFactory
    )
    {
        this.usecase = usecase;
        this.connectorFactory = connectorFactory;

        this.parser = new ConfigParser(selectorFactory);
        this.root = this.DefineCommand();
    }

    public async Task<int> InvokeAsync(string[] args)
    {
        return await this.root.InvokeAsync(args);
    }



//=====================================================================================================


    /// <summary>
    /// コマンド定義
    /// </summary>
    private RootCommand DefineCommand()
    {
        //引数
        Argument<string> app = new Argument<string>(
            "app",
            "起動対象のアプリのパス"
        );

        Argument<string> ruleConfigPath = new Argument<string>(
            "ruleConfigPath",
            "実行ルールの設定ファイル"
        );

        Argument<string[]> ruleConfigArgs = new Argument<string[]>(
            "configArgs",
            "設定ファイルに引き渡す引数"
        );

        //オプション
        Option<string> charset = new Option<string>(
            aliases: new string[] {"--charset", "-c"}, 
            description: "設定ファイルの文字コード",
            getDefaultValue: () => "UTF-8"
        );
  

        //コマンド体系を定義
        return new()
        {
            new SubCommand("launch", "実行")
            {
                app,
                ruleConfigPath,
                ruleConfigArgs,
                charset,

                CommandHandler.Create(this.Launch)
            }

        };
    }



//=====================================================================================================


    private int Launch(
        string app, 
        string ruleConfigPath, 
        string[] ruleConfigArgs,
        string charset
    )
    {
        return ExceptionUtil.TryCatch(0, 1, () => {

            //ルールコンフィグ読み込み
            var ruleSet = this.parser.ParseFromFile(
                ruleConfigPath, 
                Encoding.GetEncoding(charset),
                ruleConfigArgs
            );

            this.usecase.Inject(
                new Config(
                    this.connectorFactory.CreateLaunchConnector(app),
                    ruleSet
                )
            );
        });
    }


//=====================================================================================================







//=====================================================================================================


    /// <summary>
    /// ハンドラーを追加する Addメソッドを追加したもの
    /// </summary>
    private class SubCommand : Command
    {
        public SubCommand(string name, string? description = null) : base(name, description)
        {
            
        }

        public void Add(ICommandHandler handler)
        {
            this.Handler = handler;
        }
    }



//=====================================================================================================



}

