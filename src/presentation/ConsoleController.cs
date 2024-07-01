using System;
using System.Collections.Immutable;
using System.CommandLine;
using System.CommandLine.Invocation;
using System.CommandLine.NamingConventionBinder;
using System.Data;
using System.Runtime.Serialization;
using System.Text.Json;

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

        Argument<string> profile = new Argument<string>(
            "profile",
            "起動対象のアプリのパス"
        );

        

        // //引数
        // Argument<int> targetArgument = new Argument<int>(
        //     "target",
        //     "対象となるVisual StudioのプロセスID"
        // );

        // Argument<string> propertyPathArgument = new Argument<string>(
        //     "propertyPath",
        //     "対象となる階層を含むプロパティ名"
        // );

        // //オプション
        // Option<FormatterType> canOutputJsonOption = new Option<FormatterType>(
        //     aliases: new string[] {"--format"}, 
        //     description: "出力形式",
        //     getDefaultValue: () => FormatterType.CSV
        // );

        // Option<int> interval = new Option<int>(
        //     aliases: new string[] {"--interval"}, 
        //     description: "監視間隔(ms)",
        //     getDefaultValue: () => 50
        // );


        //コマンド体系を定義
        return new()
        {
            new SubCommand("launch", "実行")
            {
                app,
                profile,
            }



            // new SubCommand("get", "取得")
            // {
            //     new SubCommand("target", "対象となるVisualStudioのプロセスID一覧を表示する")
            //     {
            //         canOutputJsonOption,

            //         CommandHandler.Create(this.GetTarget)
            //     },

            //     new SubCommand("property", "対象のプロパティ一覧を表示する")
            //     {
            //         targetArgument,
            //         canOutputJsonOption,

            //         CommandHandler.Create(this.GetProperty)
            //     },

            //     new SubCommand("focus", "フォーカスに対応する要素および対象との関係を取得する")
            //     {
            //         targetArgument,
            //         canOutputJsonOption,

            //         CommandHandler.Create(this.GetFocus)
            //     }
            // },

            // new SubCommand("focus", "フォーカス移動")
            // {
            //     new SubCommand("property", "対象のプロパティにフォーカスする")
            //     {
            //         targetArgument,
            //         propertyPathArgument,
            //         canOutputJsonOption,

            //         CommandHandler.Create(this.FocusProperty)
            //     },
            // },

            // new SubCommand("watch", "監視")
            // {
            //     new SubCommand("focus", "フォーカスの変化を監視し、情報を取得する")
            //     {
            //         targetArgument,
            //         canOutputJsonOption,
            //         interval,

            //         CommandHandler.Create(this.WatchFocus)
            //     }
            // }
        };
    }



//=====================================================================================================

    
    // private int GetTarget(FormatterType format)
    // {   
    //     return ExceptionUtil.TryCatch(0, 1, () => {

    //         var result = this.usecase.GetTarget();
    //         Console.WriteLine(format.Format(result));
    //     });
    // }

    // private int GetProperty(int target, FormatterType format)
    // {
    //     return ExceptionUtil.TryCatch(0, 1, () => {

    //         var result = this.usecase.GetProperty(target);
    //         Console.WriteLine(format.Format(result));
    //     });
    // }

    // private int GetFocus(int target, FormatterType format)
    // {
    //     return ExceptionUtil.TryCatch(0, 1, () => {
            
    //         var result = this.usecase.GetFocus(target);
    //         Console.WriteLine(format.Format(ImmutableList.Create(result)));
    //     });
    // }

    // private int FocusProperty(int target, string propertyPath, FormatterType format)
    // {
    //     return ExceptionUtil.TryCatch(0, 1, () => {
            
    //         var result = this.usecase.FocusProperty(target, propertyPath);
    //         Console.WriteLine(format.Format(result));
    //     });
    // }

    // private int WatchFocus(int target, FormatterType format, int interval)
    // {
    //     CancellationTokenSource cts = new CancellationTokenSource();
        
    //     void output(ImmutableList<FocusInfo> result)
    //     {
    //         Console.WriteLine();
    //         Console.WriteLine(format.Format(result));
    //     }

    //     bool isStop()
    //     {
    //         return cts.Token.IsCancellationRequested;
    //     }

    //     return ExceptionUtil.TryCatch(0, 1, () => {            
            
    //         //入力待機
    //         Task.Run(() => {
    //             Console.ReadLine();
    //             cts.Cancel();
    //         });

    //         this.usecase.WatchFocus(target, interval, isStop, output);
    //     });
    // }


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

