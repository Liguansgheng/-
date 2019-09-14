package lgs.GameSnake;

import java.awt.Graphics;
import java.awt.Image;
import java.awt.Rectangle;
import java.awt.Point;

import lgs.GameUtil.Config;

public abstract class SnakeObject {
	//坐标
	int x,y;
	
	//对应图片
	Image img;
	
	//图片大小
	int ImgWidth = Config.ImageWidth;
	int ImgHeight = Config.ImageHeight;
	
	//当前状态
	public boolean IsLive;
	
	//绘画函数
	public abstract void Draw(Graphics g);
	
	/*判断实体碰撞函数参数为，两个不同的点，和允许的相交比例
	 * 由于该游戏的图形规定为正方形，并且speed和图片大小相同，因此有
	 * 很多简化，游戏中只存在正面碰撞，因此只需要计算图形中心点的距离，
	 * 再除以图片的长度，就可以得到两个图形的重叠比例（0-1），通过调整阈值，得到
	 * 两个实体是否碰撞的结果
	 */
	public boolean  IsIntersectedByDegree(Point PointA,Point PointB,float Degree) {
		//重叠比例
		float ThisDegree = 1 - (float)PointA.distance(PointB)/Config.ImageWidth;
		if(ThisDegree >=  Degree)
			return true;
		else
			return false;
	}
}
