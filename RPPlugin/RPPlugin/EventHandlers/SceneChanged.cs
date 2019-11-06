using Smod2;
using Smod2.EventHandlers;
using Smod2.Events;
using Smod2.API;

using System.Collections.Generic;

namespace RPPlugin.EventHandlers
{
    class SceneChanged : IEventHandlerSceneChanged
    {
        RPPlugin plugin;

        public SceneChanged(RPPlugin plugin)
        {
            this.plugin = plugin;
        }

        public void OnSceneChanged(SceneChangedEvent ev)
        { 
            
        }
    }
}
