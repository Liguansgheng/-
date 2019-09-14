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
	//�ߵ��ٶ�
	private int Speed;
	//�ߵĳ���
	private int Length;
	//����ͷÿ�ε��ƶ���λ�ã�����Ϊ�ߵ�����
	public static List<Point> BodyPoints = new LinkedList<>();
	//���ߵ�����ͼƬ
	public static List<String> BodyImage = new LinkedList<>();
	//��ǰ���ķ���,��ʼ��������
	boolean Up,Down,Left,Right;
	//���캯��,������ʼ��
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
	
	//Length����
	public void SetLength(int Length) {
		this.Length  = Length;
	}
	public int GetLength() {
		return this.Length;
	}
	
	//���̼���
	public void KeyPressed(KeyEvent e) {
		switch (e.getKeyCode()) {
			case KeyEvent.VK_UP:
				if (!Down) {// �������ʼ����ķ������ƶ�
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
				System.out.println("�ո�");
			}
				break;
		}
	}
	
	//�ƶ�����
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
	
	//��������
	private void OutOfBounds() {
		boolean xOut = (x <= ImgWidth/2 || x >= (Config.WindowWidth - ImgWidth/2));
		boolean yOut = (y <= ImgHeight/2 || y >= (Config.WindowHeight - ImgHeight/2));
		if (xOut || yOut) {
			IsLive = false;
		}
	}

	//������������
	private void EatBody(){
		for (Point PointA : BodyPoints) {
			for (Point PointB : BodyPoints) {
				if(PointA!=PointB&&IsIntersectedByDegree(PointA,PointB,Config.SnakeInterSectBody)){
					this.IsLive=false;//������
				}
			}
		}
	}
	//
	@Override
	public void Draw(Graphics g) {
		OutOfBounds();  //���������������
		EatBody();//���������Լ���������
		BodyPoints.add(new Point(x,y));//������ͷ��ǰ�켣����
		if(BodyPoints.size() > this.Length)  //��ֹ�ڴ��������Ȼ��̫����
			BodyPoints.remove(0);
		//������ͷ
		this.img = ImageLoad.getImage("img/" + Config.SnakeHead);
		g.drawImage(img,x,y,ImgWidth,ImgHeight,null);
		//���ߵ�����
		for(int i = Length-2 ;i>=0;i--) { //ȥ����ͷ����
			Point PointBody = BodyPoints.get(i);
			String ImageBody = BodyImage.get(Length -2-i);
			g.drawImage(ImageLoad.images.get(ImageBody), PointBody.x,PointBody.y,ImgWidth,ImgHeight,null);
		}
		move();
	}
}
