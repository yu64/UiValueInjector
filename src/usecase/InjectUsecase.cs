
using System.Collections.Immutable;
using UiValueInjector.Domain;
using UiValueInjector.Presentation;

namespace UiValueInjector.Usecase;

public class InjectUsecase
{


    public InjectUsecase()
    {

    }


    internal void Launch(RunningConfig config, AppPath appPath)
    {
        //操作対象を起動
        // IApp app = this.appFacotry.Launch(appPath);


        // config.Rules.ForEach((rule) => {

        //     ImmutableList<IElement> list = app.GetElement(rule.Selectors);
            
        //     list.ForEach((ele) => {

        //         ele.SetValue(rule.Value);
        //     });
        // });

        
        //非同期でメインループ開始

        //

        
    }
}