package lgsGameFrame;

import lgs.GameSnake.*;
import lgs.GameUtil.Config;
import lgs.GameUtil.ImageLoad;

import java.awt.Color;
import java.awt.Font;
import java.awt.Graphics;
import java.awt.Image;
import java.awt.event.KeyAdapter;
import java.awt.event.KeyEvent;
import java.awt.Button;

public class SnakeClient extends MyFrame {
	public Snake mySnake = new Snake(120, 120);//��
	public Food food = new Food();//ʳ��
	
	public void loadFrame() {
		super.loadFrame();
		//��Ӽ��̼�������������̰����¼�
		addKeyListener(new KeyAdapter() {
			@Override
			public void keyPressed(KeyEvent e) {
				mySnake.KeyPressed(e);//ί�и�mysnake
			}
		});
	}
	
	public void paint(Graphics g) {
		//g.drawImage(background, 0, 0, null);//���Ʊ���
		if(mySnake.IsLive){//����߻��ţ��ͻ���
			mySnake.Draw(g);
			if(food.IsLive){//���ʳ����ţ��ͻ���
				food.Draw(g);
				food.Eaten(mySnake);
			}else{//���򣬲�����ʳ��
				food = new Food();
			}
		}else{//��������������Ϸ��������
			this.setLayout(null);
			Button Btn = new Button("����һ��");
			Btn.setBounds(460, 350, 70, 35);
			this.add(Btn);
			Image loseimg = ImageLoad.getImage("loser/loseB.jpg");
			g.drawImage(loseimg,0,0,Config.WindowWidth,Config.WindowHeight, null);
			
		}
	}

	public static void main(String[] args) {
		new SnakeClient().loadFrame();//���ش���
	}

}
