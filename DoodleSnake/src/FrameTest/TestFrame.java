package FrameTest;

import java.awt.*;
import java.awt.event.WindowAdapter;
import java.awt.event.WindowEvent;

import lgs.GameUtil.Config;
import lgs.GameUtil.ImageLoad;

public class TestFrame extends Frame {

	/**
	 * 
	 */
	private static final long serialVersionUID = 1L;
	
	public TestFrame() {
		this.setTitle("按钮测试");// 设置窗体标题
		this.setSize(990, 600);// 设置窗体大小
		this.setLocationRelativeTo(null);// 居中
		// 设置可关闭
		this.addWindowListener(new WindowAdapter() {
			@Override
			public void windowClosing(WindowEvent e) {
				System.exit(0);
			}
		});
		// 设置可见
		/*
		 * this.setLayout(null); Button Btn = new Button("再试一次");
		 *  Btn.setBounds(460,350, 70, 35); 
		 *  this.add(Btn);
		 */
		this.setVisible(true);
	}
	
	public void paint(Graphics g) {
		this.setLayout(null);
		Button Btn = new Button("再试一次");
		Btn.setBounds(460, 350, 70, 35);
		this.add(Btn);
		Image loseimg = ImageLoad.getImage("loser/loseB.jpg");
		g.drawImage(loseimg,0,0,Config.WindowWidth,Config.WindowHeight, null);
	}
	
	public static void main(String[] args) {
		new TestFrame();
	}
}
