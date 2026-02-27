# DotNetMultiLogSample
Logging facade in DotNet is not as mature as slf4j in java.  
Instead log4net is widely used. So we can treat log4net as a common Logging facade.  
But in history, there are 3 pubkey for log4net.  
```
log4net, Version=1.2.9.0, PublicKeyToken=b32731d11ce58905
log4net, Version=1.2.10.0, PublicKeyToken=1b44e1d426115821
log4net, Version=1.2.11.0~3.3.0, PublicKeyToken=669e0ddf0bb1aa2a
```
If you meet libs using different log4net with different pubkeys, bindingRedirect won't help.  
That is the solution.


## AppUseTwoLog4net
1. How to use two libs with the same name, but with different version, even with different pubkey
2. How to route the two log4net to NLog
3. How to use ModuleInit.Fody to initialize logs


## AppCommonLoggingConfig
How to use Common.Logging with app.config


## AppCommonLoggingCode
How to use Common.Logging with code config


## AppSlf4NetConfig
How to use slf4net with app.config


## AppSlf4NetCode
How to use slf4net with code config
