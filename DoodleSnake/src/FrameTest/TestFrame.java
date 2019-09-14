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
		this.setTitle("��ť����");// ���ô������
		this.setSize(990, 600);// ���ô����С
		this.setLocationRelativeTo(null);// ����
		// ���ÿɹر�
		this.addWindowListener(new WindowAdapter() {
			@Override
			public void windowClosing(WindowEvent e) {
				System.exit(0);
			}
		});
		// ���ÿɼ�
		/*
		 * this.setLayout(null); Button Btn = new Button("����һ��");
		 *  Btn.setBounds(460,350, 70, 35); 
		 *  this.add(Btn);
		 */
		this.setVisible(true);
	}
	
	public void paint(Graphics g) {
		this.setLayout(null);
		Button Btn = new Button("����һ��");
		Btn.setBounds(460, 350, 70, 35);
		this.add(Btn);
		Image loseimg = ImageLoad.getImage("loser/loseB.jpg");
		g.drawImage(loseimg,0,0,Config.WindowWidth,Config.WindowHeight, null);
	}
	
	public static void main(String[] args) {
		new TestFrame();
	}
}
