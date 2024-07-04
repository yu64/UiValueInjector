
using System.Collections.Immutable;
using System.IO.Packaging;
using UiValueInjector.Domain;
using UiValueInjector.Presentation;

namespace UiValueInjector.Usecase;

/// <summary>
/// 要件「何かに接続し、AutomationIdなどの条件に適した要素の値を、指定回数まで変更する」
/// </summary>
public class InjectUsecase
{


    public InjectUsecase()
    {

    }


    internal void Inject(Config config)
    {

        RuleSet ruleSet = config.RuleSet;
        bool isStop = false;

        //操作対象に接続
        using IElementRepository repo = config.Connector.Connect();


        //非同期処理で監視処理
        var loopTask = Task.Run(() => {
            
            //適用できるルールがなくなるまでループする
            while(!ruleSet.IsDisable() && !repo.IsDispose() && !isStop)
            {
                //操作対象にルールを適用する
                ruleSet.ApplyTo(repo);
            }
        });

        //キー入力で停止
        var stopTask = Task.Run(() => {
            
            Console.ReadLine();
            isStop = true;
        });
        

        loopTask.Wait();
        
    }
}