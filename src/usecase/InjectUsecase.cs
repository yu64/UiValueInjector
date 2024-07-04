
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

        //操作対象を起動
        using IApp app = config.Connector.Connect();


        //非同期処理で監視処理
        RuleSet ruleSet = config.RuleSet;
        var task = Task.Run(() => {
            
            //適用できるルールがなくなるまでループする
            while(!ruleSet.IsDisable())
            {
                //操作対象にルールを適用する
                ruleSet.ApplyTo(app);
            }
        });
        

    
        
    }
}