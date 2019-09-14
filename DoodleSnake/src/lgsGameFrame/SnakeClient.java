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
	public Snake mySnake = new Snake(120, 120);//蛇
	public Food food = new Food();//食物
	
	public void loadFrame() {
		super.loadFrame();
		//添加键盘监听器，处理键盘按下事件
		addKeyListener(new KeyAdapter() {
			@Override
			public void keyPressed(KeyEvent e) {
				mySnake.KeyPressed(e);//委托给mysnake
			}
		});
	}
	
	public void paint(Graphics g) {
		//g.drawImage(background, 0, 0, null);//绘制背景
		if(mySnake.IsLive){//如果蛇活着，就绘制
			mySnake.Draw(g);
			if(food.IsLive){//如果食物活着，就绘制
				food.Draw(g);
				food.Eaten(mySnake);
			}else{//否则，产生新食物
				food = new Food();
			}
		}else{//蛇死亡，弹出游戏结束字样
			this.setLayout(null);
			Button Btn = new Button("再试一次");
			Btn.setBounds(460, 350, 70, 35);
			this.add(Btn);
			Image loseimg = ImageLoad.getImage("loser/loseB.jpg");
			g.drawImage(loseimg,0,0,Config.WindowWidth,Config.WindowHeight, null);
			
		}
	}

	public static void main(String[] args) {
		new SnakeClient().loadFrame();//加载窗体
	}

}
