
using System.Collections.Immutable;
using System.IO.Packaging;
using UiValueInjector.Domain;
using UiValueInjector.Presentation;

namespace UiValueInjector.Usecase;

public class InjectUsecase
{


    public InjectUsecase()
    {

    }


    internal void Launch(Config config, AppPath appPath)
    {
        //操作対象を起動
        IApp app = this.appFacotry.Launch(appPath);
        
        List<Rule> activeRules = config.Rules.ToList();

        

        
        activeRules.ForEach((rule) => {

            app.SetValueToElement(rule);


        });

        
        //非同期でメインループ開始

        //

        
    }
}