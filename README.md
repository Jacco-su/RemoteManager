# RemoteManager
用于对远程账户进行管理的插件式工具，目前集成了向日葵和TeamViewer两种远程工具。

采用MVVM的架构进行开发（大概）

使用的是MEF的插件框架，插件需要实现IRemoteTool接口，并注入RemoteTool特性。
开发插件时，建议继承虚类RemoteToolBase，该类实现了GetExePath方法，可根据名称读取已安装的软件路径，同时兼容32位和64位系统。
需要注意的是，插件的元数据只提供了基本的远程字段，如果需要额外的信息，可存储在ExtensionProperty属性中，当然，格式化的规则只能由你自己定，反正能以字符串储存就行。

数据存储方面，使用EF Core + Sqlite，默认数据库名称为rm.db，可在配置文件中修改数据库链接。RemoteInfo的主键是远程Id和ToolCode（插件编码），所以新增修改时，程序可能会报错。

目前实现了向日葵远程桌面、TeamViewer桌面远程和TeamViewer文件传输。


