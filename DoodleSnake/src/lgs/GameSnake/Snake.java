package lgs.GameSnake;

import java.awt.Graphics;
import java.awt.Point;
import java.awt.event.KeyEvent;
import java.awt.image.BufferedImage;
import java.util.LinkedList;
import java.util.List;
import java.awt.Dialog;

import lgs.GameUtil.Config;
import lgs.GameUtil.ImageLoad;
import lgs.GameUtil.ImageRandom;

public class Snake extends SnakeObject {
	//蛇的速度
	private int Speed;
	//蛇的长度
	private int Length;
	//存蛇头每次的移动的位置，可视为蛇的身体
	public static List<Point> BodyPoints = new LinkedList<>();
	//存蛇的身体图片
	public static List<String> BodyImage = new LinkedList<>();
	//蛇前进的方向,初始方向向右
	boolean Up,Down,Left,Right;
	//构造函数,参数初始化
	public Snake(int x,int y) {
		this.x = x;
		this.y = y;
		this.IsLive = true;
		this.Speed = Config.ImageSpeed;
		this.Length = 1;
		this.Right = true;
		this.ImgHeight = Config.ImageHeight;
		this.ImgWidth = Config.ImageWidth;
		this.img = ImageLoad.images.get(ImageRandom.GetRandomImgName());
	}
	
	//Length属性
	public void SetLength(int Length) {
		this.Length  = Length;
	}
	public int GetLength() {
		return this.Length;
	}
	
	//键盘监听
	public void KeyPressed(KeyEvent e) {
		switch (e.getKeyCode()) {
			case KeyEvent.VK_UP:
				if (!Down) {// 不能向初始方向的反方向移动
					Up = true;
					Down = false;
					Left = false;
					Right = false;
					System.out.println("up");
				}
				break;
			case KeyEvent.VK_DOWN:
				if (!Up) {
					Up = false;
					Down = true;
					Left = false;
					Right = false;
					System.out.println("down");
				}
				break;
			case KeyEvent.VK_LEFT:
				if (!Right) {
					Up = false;
					Down = false;
					Left = true;
					Right = false;
					System.out.println("left");
				}
				break;
			case KeyEvent.VK_RIGHT:
				if (!Left) {
					Up = false;
					Down = false;
					Left = false;
					Right = true;
					System.out.println("right");
				}
				break;
			case KeyEvent.VK_SPACE: {
				Config.IsSuspend = !Config.IsSuspend;
				System.out.println("空格");
			}
				break;
		}
	}
	
	//移动方向
	public void move() {
		if (Config.IsSuspend == false) {
			if (Up)
				y -= Speed;
			else if (Down)
				y += Speed;
			else if (Left)
				x -= Speed;
			else if (Right)
				x += Speed;
		}
		else {
			//
		}
	}
	
	//出界问题
	private void OutOfBounds() {
		boolean xOut = (x <= ImgWidth/2 || x >= (Config.WindowWidth - ImgWidth/2));
		boolean yOut = (y <= ImgHeight/2 || y >= (Config.WindowHeight - ImgHeight/2));
		if (xOut || yOut) {
			IsLive = false;
		}
	}

	//碰到身体问题
	private void EatBody(){
		for (Point PointA : BodyPoints) {
			for (Point PointB : BodyPoints) {
				if(PointA!=PointB&&IsIntersectedByDegree(PointA,PointB,Config.SnakeInterSectBody)){
					this.IsLive=false;//蛇死亡
				}
			}
		}
	}
	//
	@Override
	public void Draw(Graphics g) {
		OutOfBounds();  //处理身体出界问题
		EatBody();//处理碰到自己身体问题
		BodyPoints.add(new Point(x,y));//保存舌头当前轨迹坐标
		if(BodyPoints.size() > this.Length)  //防止内存溢出，虽然不太可能
			BodyPoints.remove(0);
		//加载蛇头
		this.img = ImageLoad.getImage("img/" + Config.SnakeHead);
		g.drawImage(img,x,y,ImgWidth,ImgHeight,null);
		//画蛇的身体
		for(int i = Length-2 ;i>=0;i--) { //去掉蛇头坐标
			Point PointBody = BodyPoints.get(i);
			String ImageBody = BodyImage.get(Length -2-i);
			g.drawImage(ImageLoad.images.get(ImageBody), PointBody.x,PointBody.y,ImgWidth,ImgHeight,null);
		}
		move();
	}
}
