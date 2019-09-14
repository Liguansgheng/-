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
		this.setTitle("̰����");//���ô������
		this.setSize(Config.WindowWidth, Config.WindowHeight);//���ô����С
		this.setLocationRelativeTo(null);//����
		//���ÿɹر�
		this.addWindowListener(new WindowAdapter() {
			@Override
			public void windowClosing(WindowEvent e) {
				System.exit(0);
			}
		});
		//���ÿɼ�
		this.setVisible(true);
		//�����ػ��߳�
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
