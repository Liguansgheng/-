package lgs.GameSnake;

import java.awt.Graphics;
import java.awt.Point;

import lgs.GameUtil.Config;
import lgs.GameUtil.ImageLoad;
import lgs.GameUtil.ImageRandom;

public class Food extends SnakeObject {
	String RandomName ;
	public Food() {
		this.IsLive = true;
		this.RandomName = ImageRandom.GetRandomImgName();
		this.img = ImageLoad.images.get(RandomName);
		this.ImgWidth = Config.ImageWidth;
		this.ImgHeight = Config.ImageHeight;
		this.x=ImgWidth*SetRandomCoordinate("X");
		this.y=ImgHeight*SetRandomCoordinate("Y");
		System.out.println(x + "," + y);
	}
	
	public void Eaten(Snake mySnake) {
		if (IsIntersectedByDegree(new Point(x, y), new Point(mySnake.x, mySnake.y), Config.SnakeIntersectFood) && IsLive&& mySnake.IsLive) {
			this.IsLive = false;// 食物死亡
			Snake.BodyImage.add(RandomName);
			mySnake.SetLength(mySnake.GetLength() + 1);// 长度加一
		}	
	}
	/*
	 * 把整个窗口分割为ImgWidthxImgHeight的小方块，为了使食物图片正好能
	 * 画在方块中，计算出x轴y轴最大点坐标，例
	 * 当ImgWidth = 30,WindowWidth = 990时，0< 30n< 990-30;
	 * n为可取值，且为整数
	 */
	public static int SetRandomCoordinate(String XOrY) {
		int max =0;
		if(XOrY == "X") {
			max = (Config.WindowWidth-Config.ImageWidth)/Config.ImageWidth;
			//System.out.println(max);
		}
		else if(XOrY == "Y") {
			max = (Config.WindowHeight-Config.ImageHeight)/Config.ImageHeight;
			//System.out.println(max);
		}
		else
			System.out.println("没读出来！");
		return (int)(1+Math.random()*max);
	}
	@Override
	public void Draw(Graphics g) {
		g.drawImage(img,x,y,ImgWidth,ImgHeight, null);
	}

}
