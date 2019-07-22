# Unity_Assignment1

第一次Unity作业。要求使用Unity做一个小游戏，用到Collider、Input、Transform等。

我完成的是一个简单的射击游戏，视角为俯视45度，参考游戏有《孤胆枪手》、《HellDivers》。

## 地形

地形由一个平面和数个立方体墙面组成，它们都有自身的collider，四个边缘处也放了阻隔用的墙，我将边缘处的mesh renderer设为不可见，以达到空气墙的效果，防止飞船走到地形之外。

## 角色移动（Input、Transform）

首先脚本CharacterMover获取输入，用`Input.GetAxis`判断输入水平或垂直，然后分别按横纵两个方向移动飞船，原理是获取飞船GameObject的RigidBody，然后在x轴和z轴方向设置速度velocity，并乘上一个浮点型`speed`，控制速度大小，为了让速度不会被当前PC的帧数影响，再乘以`Time.deltaTime`。

## 子弹生成（Prefab）

可以移动角色后，下面就是发射子弹了，脚本BulletSpawner，在飞船头部创建一个空GameObject作为FirePoint，方便后面旋转时的瞄准。用空白处创建的Capsule模型作为子弹，拖入Project栏中的Prefab文件夹生成模板，然后在`Update`函数中检测“Fire1”即鼠标左键是否被按下，按下则用`Instantiate`方法生成子弹模板，同时子弹模板上附上BulletMover，这样在生成后可以立马往前方移动（发射）。

## 鼠标瞄准（Quaternion、Ray）

脚本Aimer负责瞄准，要在3D环境中实现平面的瞄准，需要得到鼠标在摄像机屏幕坐标的位置，再将其转换成一个Ray，首先需要初始化一个plane，它的法线垂直向上（y轴），并经过原点。然后要用到Plane.Raycast方法，根据官方文档的描述，它的功能是：

    This function sets enter to the distance along the ray, where it intersects the plane. If the ray is parallel to the plane, function returns false and sets enter to zero.

这里的enter是该方法的第二个参数，也就是说，我们可以实时获得鼠标位置在该平面上的一个ray，函数`Plane.Raycast`会将其设置成ray的长度，我们假设这个ray从原点出发，那么我们已经得到了鼠标在该plane上的位置，剩下的就只需要将其转换为坐标，然后计算和当前飞船的距离，从而得出角度，最后将飞船的rotation设置为相应的角度就行了。

## 子弹检测（Collider）

将子弹模板的Collider设置为isTrigger，然后就可以用`OnTriggerEnter`方法来判断和其碰撞的其他collider是什么物体了，这里我们分几种情况，首先发射子弹时可能会碰到飞船自身，所以这种情况什么都不做，而如果碰到敌人，就调用敌人身上的脚本`Enemy`中的`takeDamage`方法扣血，如果血量降到零以下，那么敌人被击杀，用`Destroy`销毁敌人GameObject，同时生成一个死亡特效，当然最后不要忘了将这个死亡特效在数秒后也销毁，节省空间。还有一种情况，就是子弹碰到除自身和敌人之外的情况，这里只有可能是墙，这种情况直接销毁子弹，达到障碍物阻挡子弹的效果。

## UI

加了一个简单的UI，用来重新开始或者退出游戏，重新开始用`SceneLoader`方法重新载入当前场景。

最顶端还加了一个计分板，每消灭一个敌人加一分，分数储存用到了`PlayerPrefs`储存整形数据，然后用一个Coroutine每隔0.1秒读取并刷新一次当前分数。

## 所用素材

用了Standard Assets中的三个素材，一个人物模型用来充当敌人，一个飞船机翼用来装饰操控的飞船，最后是一个粒子效果Explosion用来充当死亡特效。

## 最后

本来想加更多功能，比如可以在地图上随机生成NPC并随机移动，甚至更多的关卡，但是还有其他作业，时间不够。
