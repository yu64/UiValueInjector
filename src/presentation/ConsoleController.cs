using System;
using System.Collections.Immutable;
using System.CommandLine;
using System.CommandLine.Invocation;
using System.CommandLine.NamingConventionBinder;
using System.Data;
using System.Runtime.Serialization;
using System.Text.Json;
using WinFormsPropertyFinder.cui;

namespace UiValueInjector;


public class ConsoleController
{   
    private readonly Usecase usecase;
    private readonly RootCommand root;
    
    public ConsoleController(Usecase usecase)
    {
        this.usecase = usecase;
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

        Argument<string> runningConfig = new Argument<string>(
            "runningConfig",
            "実行内容の設定ファイル"
        );

        Argument<string[]> configArgs = new Argument<string[]>(
            "configArgs",
            "設定ファイルに引き渡す引数"
        );

  

        //コマンド体系を定義
        return new()
        {
            new SubCommand("launch", "実行")
            {
                app,
                runningConfig,
                configArgs,

                CommandHandler.Create(this.Launch)
            }

        };
    }



//=====================================================================================================


    private int Launch(string app, string runningConfig, string[] configArgs)
    {
        return ExceptionUtil.TryCatch(0, 1, () => {


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

