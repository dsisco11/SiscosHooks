# SiscosHooks
A library for hooking into events within the <a href="http://store.steampowered.com/app/433340/">SlimeRancher</a> game.  
Please note it is the _PLAYER_ who needs to install this mod.  
Plugins cannot use it unless the player has it installed.  
Additionally plugin creators do not need any of the code from this library, they only need to reference the assembly. And read the wiki, the wiki is also important...  
  

### What?
More specifically this mod intercepts certain events and functions in SlimeRancher and then allows plugins to register callbacks for those events, even going so far as allowing plugins to alter any of the event functions parameters or return values!  
<ul>
<li>Change plort market values.</li>
<li>Alter entity spawn rates/limits.</li>
<li>Alter weapon functionality</li>
<li>(Soon) Add custom upgrades</li>
<li>Much more!</li>
</ul>


### Installing
The library comes with an installer which will inject it into your game much like a plugin loader would.  
To download the installer click <a href="https://github.com/dsisco11/SiscosHooks/raw/master/Installer.zip">HERE</a>.  
If you need more information about installing visit the <a href="wiki">wiki</a>.

### Usage
Visit the <a href="https://github.com/dsisco11/SiscosHooks/wiki">wiki</a>.

## License
SiscosHooks is released under the <a href="https://tldrlegal.com/license/apache-license-2.0-(apache-2.0)">Apache 2.0 license</a>


# FAQ
### "An event I need isn't supported!"
_Well too bad bucko._
Nah, only joking. Just create an issue on the projects github page and I'll see what I can do about it.



