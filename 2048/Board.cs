using System;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

public class Board
{

    private Tile[,] matrix;
    public Board()
    {
        matrix = new Tile[4, 4];
        for (int i = 0; i < 4; i++)
        {
            for (int j = 0; j < 4; j++)
            {
                matrix[i, j] = new Tile(0);
            }
        }
    }
    public Tile[,] getMatrix()
    {
        return matrix;
    }
    private int GetRandomNumberToAdd24()
    {
        int numberToAdd = 2;
        Random random = new Random();
        int x = random.Next(10) + 1;
        if (x == 10)
            numberToAdd = 4;

        return numberToAdd;
    }
    public int GetRandomNumberToAdd()
    {
        Random random = new Random();
        return (random.Next(0, 4));
    }
    public void AddRandomNum()
    {
        // הנחות: יש לפחות מקום אחד ריק במטריצה
        int numberTOAdd1 = GetRandomNumberToAdd24();
        int numberToI = GetRandomNumberToAdd();
        int numberToJ = GetRandomNumberToAdd();
        while (matrix[numberToI, numberToJ].getNum() != 0)
        {
            numberToI = GetRandomNumberToAdd();
            numberToJ = GetRandomNumberToAdd();
        }
        this.matrix[numberToI, numberToJ].setNum(numberTOAdd1);

    }
    public bool IsEmpty(int row, int column)
    {
        return (matrix[row, column].getNum() == 0);
    }
    public bool IsGameOver()
    {
        int count = 0;
        // בודק האם כל הערכים במטריצה מלאים
        for (int i = 0; i < 4; i++)
        {
            for (int j = 0; j < 4; j++)
            {
                if (matrix[i, j].getNum() == 0)
                    return false;
            }
        }
        // בודק האם יש הזזות שאפשר לבצע כדי שהמשחק לא יפסל, כלומר האם לכל איבר יש איבר שצמוד אליו ששוה לו
        // "בודקת גם מקרים בהם אין עוד ערך אחרי,כלומר אין עם מי להשוות "המספרים החיצוניים במטריצה
        for (int i = 0; i < 4; i++)
        {
            for (int j = 0; j < 4; j++)
            {
                if (matrix[i + 1, j] == null)
                    if (matrix[i, j].getNum() == matrix[i, j + 1].getNum())
                        count++;
                if (matrix[i, j + 1] == null)
                    if (matrix[i, j].getNum() == matrix[i + 1, j].getNum())
                        count++;
                if (matrix[i, j].getNum() == matrix[i, j + 1].getNum() && matrix[i, j].getNum() == matrix[i + 1, j].getNum())
                    count++;

            }
        }
        return (count == 16);
    }
    public void Board_keyUp()
    {
        for (int column = 0; column < 4; column++)
        {
            for (int row = 0; row < 3; row++)
            {
                MoveCellUP(row, column);
            }
        }
    }
    public bool MoveCellUP(int i, int j)
    {
        if (IsEmpty(i, j))
        {
            if (!IsEmpty(i + 1, j))
            {
                matrix[i, j].setNum(matrix[i + 1, j].getNum());
                matrix[i + 1, j].setNum(0);
                return true;
            }
        }
        if (matrix[i + 1, j].getNum() == matrix[i, j].getNum())
        {
            matrix[i, j].setNum(matrix[i, j].getNum() * 2);
            matrix[i + 1, j].setNum(0);
            return true;
        }
        return false;
    }
    public void Board_keyDown()
    {
        for (int column = 0; column < 4; column++)
        {
            for (int row = 3; row > 0; row--)
            {
                MoveCellDown(row, column);
            }
        }
    }
    public bool MoveCellDown(int i, int j)
    {
        if (IsEmpty(i, j))
        {
            if (!IsEmpty(i - 1, j))
            {
                matrix[i, j].setNum(matrix[i - 1, j].getNum());
                matrix[i - 1, j].setNum(0);
                return true;
            }
        }
        if (matrix[i - 1, j].getNum() == matrix[i, j].getNum())
        {
            matrix[i, j].setNum(matrix[i, j].getNum() * 2);
            matrix[i - 1, j].setNum(0);
            return true;
        }
        return false;
    }
    public void Board_keyRight()
    {
        for(int i=0;i<4;i++)
        {
            for(int j=3;j>0;j--)
            {
                MoveCellRight(i, j);
            }
        }
    }
    public bool MoveCellRight(int i, int j)
    {
        if(IsEmpty(i,j))
        {
            if(!IsEmpty(i,j-1))
            {
                matrix[i, j].setNum(matrix[i, j - 1].getNum());
                matrix[i ,j-1].setNum(0);
                return true;
            }
        }
        if (matrix[i, j].getNum() == matrix[i,j-1].getNum())
        {
            matrix[i, j].setNum(matrix[i,j].getNum() * 2);
            matrix[i,j-1].setNum(0);
            return true;
        }
        return false;
    }
    public void Board_keyLeft()
    {
        for (int i = 0; i < 4; i++)
        {
            for (int j = 0; j <3; j++)
            {
                MoveCellLeft(i, j);
            }
        }
    }
    public bool MoveCellLeft(int i, int j)
    {
        if (IsEmpty(i, j))
        {
            if (!IsEmpty(i, j + 1))
            {
                matrix[i, j].setNum(matrix[i, j + 1].getNum());
                matrix[i, j + 1].setNum(0);
                return true;
            }
        }
        if (matrix[i, j].getNum() == matrix[i, j + 1].getNum())
        {
            matrix[i, j].setNum(matrix[i, j].getNum() * 2);
            matrix[i, j + 1].setNum(0);
            return true;
        }
        return false;
    }
}