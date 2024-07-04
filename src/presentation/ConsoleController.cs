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
    private readonly RunningConfigParser parser;
    private readonly RootCommand root;
    
    public ConsoleController(
        InjectUsecase usecase
    )
    {
        this.usecase = usecase;
        this.parser = new RunningConfigParser();
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

        Argument<string> configPath = new Argument<string>(
            "configPath",
            "実行ルールの設定ファイル"
        );

        Argument<string[]> configArgs = new Argument<string[]>(
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
                configPath,
                configArgs,
                charset,

                CommandHandler.Create(this.Launch)
            }

        };
    }



//=====================================================================================================


    private int Launch(
        string app, 
        string configPath, 
        string[] configArgs,
        string charset
    )
    {
        return ExceptionUtil.TryCatch(0, 1, () => {

            //コンフィグ読み込み
            var config = this.parser.ParseFromFile(
                configPath, 
                Encoding.GetEncoding(charset),
                configArgs
            );

            this.usecase.Launch(
                config,
                new AppPath(app)
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

