package lgs.GameUtil;

//提供游戏的主要参数和加载图片函数
public class Config {
	//窗口宽度，窗口高度，应该分别为图片长宽的整数倍
	public static final int WindowWidth = 990;
	public static final int WindowHeight = 600;
	
	//图片宽度，图片高度，正方形
	public static final int ImageWidth = 30;
	public static final int ImageHeight = 30;
	
	//图片移动速率：要和图片的长宽一样
	public static final int ImageSpeed = 30;
	
	//难度(窗体刷新速率)：后期修改难度会用到，速率越大，蛇的速度越快
	public static final int Difficulty = 60;
	
	//蛇吃食物的碰撞阈值
	public static final float SnakeIntersectFood = 0.01f;
	
	//蛇碰到身体的碰撞阈值
	public static final float SnakeInterSectBody = 0.01f;
	
	//蛇头图片
	public static final String SnakeHead = "funny_white.jpg"; 
	
	//暂停状态,默认false
	public static Boolean IsSuspend = false;

}
