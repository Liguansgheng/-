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
			this.IsLive = false;// ʳ������
			Snake.BodyImage.add(RandomName);
			mySnake.SetLength(mySnake.GetLength() + 1);// ���ȼ�һ
		}	
	}
	/*
	 * ���������ڷָ�ΪImgWidthxImgHeight��С���飬Ϊ��ʹʳ��ͼƬ������
	 * ���ڷ����У������x��y���������꣬��
	 * ��ImgWidth = 30,WindowWidth = 990ʱ��0< 30n< 990-30;
	 * nΪ��ȡֵ����Ϊ����
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
			System.out.println("û��������");
		return (int)(1+Math.random()*max);
	}
	@Override
	public void Draw(Graphics g) {
		g.drawImage(img,x,y,ImgWidth,ImgHeight, null);
	}

}
