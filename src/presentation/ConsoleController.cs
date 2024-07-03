using System.Collections.Immutable;
using System.CommandLine;
using System.CommandLine.Invocation;
using System.CommandLine.NamingConventionBinder;
using System.Data;
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

            // var text = this.parser.test(new RunningConfig(new List<Domain.Rule>()
            // {
            //     new Domain.Rule(
            //         new RuleName("key"),
            //         TimingType.Always,
            //         new RuleValue("value"),
            //         ImmutableList.Create(
            //             new ElementSelector(ElementFilterType.AutomationId, ""),
            //             new ElementSelector(ElementFilterType.ControlType, "DataItem")
            //         )
            //     )
            // }));

            // Console.WriteLine(text);


            // var obj = this.parser.ParseFromJson("""""
            // {
            //     "rules": [
            //         {
            //             "name": "name0",
            //             "timing": "Always",
            //             "value": "value0",
            //             "selectors": [

            //                 {
            //                     "type": "AutomationId",
            //                     "value": "id"
            //                 }
            //             ]
            //         }
            //     ]

            // }
            // """"");

            // var obj = this.parser.ParseFromYaml("""""
            //   rules:
            //   - name: name0
            //     timing: Always
            //     value: value0
            //     selectors:
            //       - type: AutomationId
            //         value: id
            // """"");

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

