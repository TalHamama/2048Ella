using System;
using System.Drawing;
using System.Windows.Forms;

public class Tile
{
    //  תכונות
    private int num;
  
   //פעולות 
    public int getNum() { return num; }
    public Color getColor() {
        switch (this.num)
        {
            case 2:
                return Color.Gray;
            case 4:
                return Color.Wheat;
            case 8:
                return Color.Gold;
            case 16:
                return Color.Orange;
            case 32:
                return Color.OrangeRed;
            case 64:
                return Color.IndianRed;
            case 128:
                return Color.RoyalBlue;
            case 256:
                    return Color.YellowGreen;
            case 512:
                return Color.LightBlue;
            case 1024:  
                return Color.SeaShell;
            case 2048:
                return Color.Magenta;
            case 4096:
                return Color.Salmon;
            default: return Color.White;
        } 
    }
    
    public void setNum(int num) { this.num = num;}
    
    public Tile(int num) {
        this.num = num;
   
    }
}
