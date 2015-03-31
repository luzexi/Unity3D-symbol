Unity3D symbol
=================

# Unity3D宏定义工具(Unity3D symbol tool)
  可以方便开启，关闭，以及增加，删除宏定义.(It can open symbol , close symbol or delete symbol)
  宏定义通过图形界面进行操作。(It can operate in graphical.)

# 如何使用( How to )
* 打开unity3d(Open unity3d)
* 点击菜单中DEFINE_TOOL->TOOL(Click menu DEFINE_TOOL->TOOL)
![github](https://github.com/luzexi/Unity3D-symbol/blob/master/img1.png "示意图1")
* 点击edit template 按钮(Click edit template button)
![github](https://github.com/luzexi/Unity3D-symbol/blob/master/img2.png "示意图2")
* 在文件中增加宏定义名称用换行区分(Add define in the file split by line)
![github](https://github.com/luzexi/Unity3D-symbol/blob/master/img3.png "示意图3")
* 点击重载按钮查看现有宏定义(Click reload button)
![github](https://github.com/luzexi/Unity3D-symbol/blob/master/img4.png "示意图4")
* 点选你需要的宏定义(Click what you want to define)
![github](https://github.com/luzexi/Unity3D-symbol/blob/master/img5.png "示意图5")
* 在代码里使用宏定义(You can use define in the code)

# 代码(code)
```c#
    #if CN_MAST
        Debug.Log("ok in the symbol.");
    #endif
```

技术分享请关注: http://www.luzexi.com
--------------------------------
![github](https://github.com/luzexi/Unity3D-symbol/blob/master/img.png "示意图")
