# SiscosHooks
A library for hooking into events within the <a href="http://store.steampowered.com/app/433340/">SlimeRancher</a> game.  
Please note it is the _PLAYER_ who needs to install this mod.  
Plugins cannot use it unless the player has it installed.  
  

### What?
More specifically this mod intercepts certain events and functions in SlimeRancher and then allows plugin developers to register callbacks for and be notified of those events, even going as far as allowing plugins to alter any of the event functions parameters or return values!  
<ul>
<li>Change plort market values.</li>
<li>Alter entity spawn rates/limits.</li>
<li>Alter weapon functionality</li>
<li>(Soon) Add custom upgrades</li>
<li>Much more!</li>
</ul>


### Installing the plugin loader
The library comes with an installer which will inject it into your slimerancher much like a plugin loader would.  
To download the installer click <a href="https://github.com/dsisco11/SiscosHooks/raw/master/Installer.zip">HERE</a>.  
If you need more information about installing visit the <a href="wiki">wiki</a>.

### Installing plugins
To install a plugin copy the folder containing the plugin DLL and any of its related icons or thumbnails to the _plugins_ folder within your SlimeRancher install directory.  
On windows by default this should be `C:\Program Files (x86)\Steam\steamapps\common\Slime Rancher\plugins`

### Usage
Visit the <a href="https://github.com/dsisco11/SiscosHooks/wiki">wiki</a>.


# FAQ
### "An event I need isn't supported!"
_Well too bad bucko._
Nah, only joking. Just create an issue on the projects github page and I'll see what I can do about it.



