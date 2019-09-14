package lgsGameFrame;

import java.awt.Color;
import java.awt.Frame;
import java.awt.Graphics;
import java.awt.Image;
import java.awt.event.WindowAdapter;
import java.awt.event.WindowEvent;

import lgs.GameUtil.Config;

public class MyFrame extends Frame {
	public void loadFrame(){
		this.setTitle("贪吃蛇");//设置窗体标题
		this.setSize(Config.WindowWidth, Config.WindowHeight);//设置窗体大小
		this.setLocationRelativeTo(null);//居中
		//设置可关闭
		this.addWindowListener(new WindowAdapter() {
			@Override
			public void windowClosing(WindowEvent e) {
				System.exit(0);
			}
		});
		//设置可见
		this.setVisible(true);
		//运行重绘线程
		new MyThread(Config.Difficulty).start();
	}
	class MyThread extends Thread{
		private int Difficulty;
		public MyThread(int Difficulty) {
			this.Difficulty = Difficulty;
		}
		@Override
		public void run() {
			while(true){
				repaint();
				try {
					sleep(Difficulty);
				} catch (InterruptedException e) {
					e.printStackTrace();
				}
			}
		}
	}

}
