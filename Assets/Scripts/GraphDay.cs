using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using CodeMonkey.Utils;

public class GraphDay : MonoBehaviour
{
    //ดรอปดาว
    private string DayS;
    private string MountS;
    private string MountShow;
    private string YearS;
    private string GameS;
    private string SummitS;
    private string user;
    private string game;
    private string time;
    private string lines;
    private string graphdmy;
    public GameObject Dayd;
    public GameObject Mountd;
    public GameObject Yeard;
    public GameObject Gamed;
    public GameObject SBtnD;
    public GameObject SBtnM;
    public GameObject SBtnY;
    public Dropdown DayD;
    public Dropdown MountD;
    public Dropdown YearD;
    public Dropdown GameD;
    public Text daychart;
    public Text dmy;
    public Text dayname;
    public Text ts1;
    public Text ts2;
    public Text ts3;
    public Text ts4;
    private List<int> sum = new List<int>() { 1 };
    private List<int> point = new List<int>() { 1};
    
    List<string> Day = new List<string>() { "วัน", "1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12", "13", "14", "15", "16", "17", "18", "19", "20", "21", "22", "23", "24", "25", "26", "27", "28", "29", "30", "31" };
    List<string> Mount = new List<string>() { "เดือน", "มกราคม", "กุมภาพันธ์", "มีนาคม", "เมษายน", "พฤษภาคม", "มิถุนายน", "กรกฏาคม", "สิงหาคม", "กันยายน", "ตุลาคม","พฤศจิกายน", "ธันวาคม" };
    List<string> Year = new List<string>() { "1" };
    List<string> gameg = new List<string>() {"เลือกรูปแบบ","รูปแบบที่ 1", "รูปแบบที่ 2", "รูปแบบที่ 3", "รูปแบบที่ 4", "รูปแบบที่ 5", };
    int a = 2563;
    string b;
    //-----//

    //private static Window_Graph instance; 
    [SerializeField] private Sprite dotSprite;
    private RectTransform graphContainer;
    private RectTransform labelTemplateX;
    private RectTransform labelTemplateY;
    private RectTransform dashTemplateX;
    private RectTransform dashTemplateY;
    private List<GameObject> gameObjectList;

    private List<int> valueList;
    private IGraphVisual graphVisual;
    private int maxVisibleValueAmount;
    private Func<int, string> getAxisLabelX;
    private Func<float, string> getAxisLabelY;



    private void Awake()
    {
        //dropdown--

        graphdmy = PlayerPrefs.GetString("graph");
        Debug.Log(graphdmy);
        Year.Clear();
        for (int i = 0; i<= 11;i++)
        {
            if(i == 0)
            {
                Year.Add("ปี");
            }
            else
            {
                b = a.ToString();
                Year.Add(b);
                a++;
            }         
        }

        DayD.AddOptions(Day);
        MountD.AddOptions(Mount);
        YearD.AddOptions(Year);
        GameD.AddOptions(gameg);
        //---------//

        //***setgraph**[//

        if (graphdmy == "day")
        {
            Debug.Log("dddd");
            dmy.text = ("รายวัน");
            dayname.text = ("ครั้งที่");
            Dayd.SetActive(true);
            Mountd.SetActive(true);
            Yeard.SetActive(true);
            Gamed.SetActive(true);
            SBtnD.SetActive(true);
            SBtnM.SetActive(false);
            SBtnY.SetActive(false);

        }
        else if (graphdmy == "mount")
        {
            Debug.Log("mmmm");
            dmy.text = ("รายเดือน");
            dayname.text = ("วัน");
            Dayd.SetActive(false);
            Mountd.SetActive(true);
            Yeard.SetActive(true);
            Gamed.SetActive(true);
            SBtnD.SetActive(false);
            SBtnM.SetActive(true);
            SBtnY.SetActive(false);

        }
        else
        {
            Debug.Log("yyyy");
            dmy.text = ("รายปี");
            dayname.text = ("เดือน");
            Dayd.SetActive(false);
            Mountd.SetActive(false);
            Yeard.SetActive(true);
            Gamed.SetActive(true);
            SBtnD.SetActive(false);
            SBtnM.SetActive(false);
            SBtnY.SetActive(true);

        }


        //*************//
        //****คะแนนเข้าList****//

        
        //*******************//
        graphContainer = transform.Find("graphContainer").GetComponent<RectTransform>();
        labelTemplateX = graphContainer.Find("labelTemplateX").GetComponent<RectTransform>();
        labelTemplateY = graphContainer.Find("labelTemplateY").GetComponent<RectTransform>();
        dashTemplateX = graphContainer.Find("dashTemplateX").GetComponent<RectTransform>();
        dashTemplateY = graphContainer.Find("dashTemplateY").GetComponent<RectTransform>();
        

        gameObjectList = new List<GameObject>();

        List<int> valueList = new List<int>() { 5, 50, 56, 45, 30, 22, 17, 15, 13, 17, 25, 37, 40, 36, 33, 50, 30, 60, 50, 40, 20, 5, 20, 10, 50, 30, 20, 11, 45, 25, 19 };
        //List<int> valueList = new List<int>() { 5, 98, 56, 45, 30, 22, 17, 15, 13, 17, 25, 37, 40, 36, 33 };
        //List<int> valueList = new List<int>() { 5};
        IGraphVisual lineGraphVisual = new LineGraphVisual(graphContainer, dotSprite, Color.magenta, new Color(1, 1, 1, .5f));
        IGraphVisual barChartVisual = new BarChartVisual(graphContainer, Color.gray, 0.8f);
        //ShowGraph(valueList , lineGraphVisual, -1,(int _i) => "" + (_i + 1), (float _f) => "$" + Mathf.RoundToInt(_f));
        ShowGraph(valueList, barChartVisual, -1, (int _i) => "" + (_i + 1), (float _f) => "$" + Mathf.RoundToInt(_f));

        //-------------test-------------//

        //-----------------------------//
        
        transform.Find("barChartBtn").GetComponent<Button_UI>().ClickFunc = () =>
        {
            SetGraphVisual(barChartVisual);
        };
        transform.Find("lineGraphBtn").GetComponent<Button_UI>().ClickFunc = () =>
        {
            SetGraphVisual(lineGraphVisual);
        };
        transform.Find("decreaseVisibleAmountBtn").GetComponent<Button_UI>().ClickFunc = () =>
        {
            DecreaseVisibleAmount();
        };
        transform.Find("increaseVisibleAmountBtn").GetComponent<Button_UI>().ClickFunc = () =>
        {
            IncreaseVisibleAmount();
        };
        transform.Find("show").GetComponent<Button_UI>().ClickFunc = () =>
        {
            setPoint(point);
        };

        //bool useBarChart = true;
        //FunctionPeriodic.Create(() =>
        //{
        //    if(useBarChart)
        //    {
        //        ShowGraph(valueList, barChartVisual, -1, (int _i) => "" + (_i + 1), (float _f) => "$" + Mathf.RoundToInt(_f));
        //    }
        //    else
        //    {
        //        ShowGraph(valueList, lineGraphVisual, -1, (int _i) => "" + (_i + 1), (float _f) => "$" + Mathf.RoundToInt(_f));
        //    }
        //    useBarChart = !useBarChart;
        //}, .5f);

        //ShowTooltip("This is a tooltip", new Vector2(100, 100));
    }

    public void LoadScene(string scenename)
    {
        SceneManager.LoadScene(scenename);
    }
    public void aaaa(int index)
    {
        Debug.Log(index);
        ts1.text = Day[index];
        DayS = Day[index];
        if(index == 0)
        {
            Debug.Log("ยังไม่ได้เลือกวัน");
        }
    }
    public void bbbb(int mm)
    {
        Debug.Log(mm);
        MountShow = Mount[mm];
        if (mm == 1)
        {
            MountS = "1";
        }
        else if (mm == 2)
        {
            MountS = "2";
        }
        else if (mm == 3)
        {
            MountS = "3";
        }
        else if (mm == 4)
        {
            MountS = "4";
        }
        else if (mm == 5)
        {
            MountS = "5";
        }
        else if (mm == 6)
        {
            MountS = "6";
        }
        else if (mm == 7)
        {
            MountS = "7";
        }
        else if (mm == 8)
        {
            MountS = "8";
        }
        else if (mm == 9)
        {
            MountS = "9";
        }
        else if (mm == 10)
        {
            MountS = "10";
        }
        else if (mm == 11)
        {
            MountS = "11";
        }
        else if (mm == 12)
        {
            MountS = "12";
        }
        else
        {
            Debug.Log("ยังไม่ได้เลือกเดือน");
        }
        ts2.text = Mount[mm];
    }
    public void cccc(int inde)
    {
        Debug.Log(inde);
        ts3.text = Year[inde];
        YearS = Year[inde];
    }
    public void dddd(int gggg)        
    {
        Debug.Log(gggg);
        if (gggg == 1)
        {
            GameS = "1";
            ts4.text = GameS;
        }
        else if(gggg == 2)
        {
            GameS = "2";
            ts4.text = GameS;
        }
        else if (gggg == 3)
        {
            GameS = "3";
            ts4.text = GameS;
        }
        else if (gggg == 4)
        {
            GameS = "4";
            ts4.text = GameS;
        }
        else if (gggg == 5)
        {
            GameS = "5";
            ts4.text = GameS;
        }
        else
        {
            Debug.Log("ยังไม่ได้เลือกรูปแบบ");
        }
    }
    public void ClickSearchD ()
    {
        Debug.LogWarning(DayS+" "+MountS+" พ.ศ."+YearS);
        daychart.text = "วันที่ "+DayS + " " + MountShow + " พ.ศ." + YearS;
        user = PlayerPrefs.GetString("user");
        string part = Application.persistentDataPath + "/" + user + "point" + ".txt";
        lines = File.ReadAllText(part);
        if (DayS != "0" && MountS != "0" && YearS != "0" && GameS != "0")
        {
            Debug.Log("เข้า1");
            SummitS = DayS+"/"+MountS+"/"+YearS;
            string[] check = lines.Split('|');
            point.Clear();
            for(int i = 1; i< check.Length;i+=4)
            {
                Debug.Log("เข้า"+i);
                if(check[i] == GameS)
                {
                    if (check[i + 1] == SummitS)
                    {
                        Debug.Log("แอด");
                        Debug.Log(check[i + 1]);
                        Debug.Log(check[i + 2]);
                        point.Add(Convert.ToInt16(check[i + 2]));
                    }
                }               
            }
        }
        else
        {
            Debug.Log("ลืมใส่ไรป่าว");
        }             
    }
    public void ClickSearchM()
    {
        Debug.LogWarning(DayS + " " + MountS + " พ.ศ." + YearS);
        daychart.text ="เดือน " + MountShow + " พ.ศ." + YearS;
        user = PlayerPrefs.GetString("user");
        string part = Application.persistentDataPath + "/" + user + "point" + ".txt";
        lines = File.ReadAllText(part);
        sum.Clear();
        point.Clear();
        Debug.Log(user);
        int nub = 0;
        if (MountS != "0" && YearS != "0")
        {
            Debug.Log("ifแรก");
            string[] check = lines.Split('|');
            int mountn = 0;
            if(MountS == "1" || MountS == "3" || MountS == "5" || MountS == "7" || MountS == "8" || MountS == "10" || MountS == "12")
            {
                Debug.Log("31วัน");
                mountn = 31;
            }
            else if (MountS == "4" || MountS == "6" || MountS == "9" || MountS == "11")
            {
                Debug.Log("30วัน");
                mountn = 30;
            }
            else if (MountS == "2")
            {
                Debug.Log("กุมภา");
                int yearnum = Convert.ToInt16(YearS);
                if((yearnum%400 == 0) || (yearnum%100 == 0) || (yearnum%4 == 0))
                {
                    mountn = 29;
                }
                else
                {
                    mountn = 28;
                }
            }           
            for(int i = 1;i<mountn+1;i++)
            {
                double sum = 0.0;
                int sumd = 0;
                //int sum = 0;
                
                Debug.Log("ฟอแรก------->" + i);
                SummitS = i.ToString()+"/" + MountS + "/" + YearS;
                for (int j = 1; j < check.Length; j += 4)
                {
                    Debug.Log("ฟอ2");
                    string[] CM = check[j + 1].Split('/');
                    Debug.Log(check[j + 1]);
                    Debug.Log(MountS + "/" + YearS);
                    Debug.Log(CM[0]);
                    Debug.Log(CM[1]);
                    Debug.Log(CM[2]);
                    if (CM[0] == i.ToString() && CM[1] == MountS && CM[2] == YearS)
                    {
                        Debug.Log("แอด---------------------------------------");
                        print("แอด---------------------------------------");
                        if (check[j] == GameS)
                        {
                            nub += 1;
                            Debug.Log("รูปแบบ------------------------------------------");
                            sumd = sumd + Convert.ToInt16(check[j + 2]);
                            
                            Debug.Log(sumd);
                            Debug.Log(nub);
                        }
                    }
                }
                //point.Add(sumd);
                //Debug.Log("Add : -------->" + sumd);
                //Debug.Log("nub : -------->" + nub);
                //sumd = sumd / nub;
                //sum = Convert.ToInt16(sumd);
                if (nub > 0)
                {
                    sumd = sumd / nub;
                    point.Add(sumd);
                }
                else
                {
                    point.Add(sumd);
                }
                //sumd = Convert.ToInt16(sum);

                nub = 0;
            }
        }
        else
        {
            Debug.Log("ลืมใส่ไรป่าว");
        }
    }
    public void ClickSearchY()
    {
        user = PlayerPrefs.GetString("user");
        string part = Application.persistentDataPath + "/" + user + "point" + ".txt";
        lines = File.ReadAllText(part);
        Debug.LogWarning(DayS + " " + MountS + " พ.ศ." + YearS);
        daychart.text = "ปี " + YearS;
        point.Clear();
        if (YearS != "0")
        {
            string[] check = lines.Split('|');
            for (int i = 1;i<13;i++)
            {
                Debug.Log("ฟอแรก");
                int sumd = 0;
                int nub = 0;
                string MountS = i.ToString();
                Debug.Log(MountS);
                int mountn = 0;
                if (MountS == "1" || MountS == "3" || MountS == "5" || MountS == "7" || MountS == "8" || MountS == "10" || MountS == "12")
                {
                    Debug.Log("31วัน");
                    mountn = 31;
                }
                else if (MountS == "4" || MountS == "6" || MountS == "9" || MountS == "11")
                {
                    Debug.Log("30วัน");
                    mountn = 30;
                }
                else if (MountS == "2")
                {
                    Debug.Log("กุมภา");
                    int yearnum = Convert.ToInt16(YearS);
                    if ((yearnum % 400 == 0) || (yearnum % 100 == 0) || (yearnum % 4 == 0))
                    {
                        mountn = 29;
                    }
                    else
                    {
                        mountn = 28;
                    }
                }
                for (int j = 1; j < mountn + 1; j++)
                {
                    Debug.Log("ฟอ2");
                    SummitS = j.ToString() + "/" + MountS + "/" + YearS;
                    
                    for (int k = 1; k < check.Length; k += 4)
                    {
                        Debug.Log("ฟอ3");
                        string[] CM = check[k + 1].Split('/');
                        Debug.Log(CM[0]);
                        if (CM[0] == j.ToString() && CM[1] == MountS && CM[2] == YearS)
                        {
                            Debug.Log("แอด");
                            if (check[k] == GameS)
                            {
                                Debug.Log("รูปแบบ");
                                sumd = sumd + Convert.ToInt16(check[k + 2]);
                                nub++; 
                            }
                        }
                        else if (CM[0] != j.ToString() && CM[1] == MountS && CM[2] == YearS)
                        {
                            sumd = sumd+ 0;
                        }
                    }                   
                }
                if(nub > 0)
                {
                    sumd = sumd / nub;
                    point.Add(sumd);
                }
                else
                {
                    point.Add(sumd);
                }
                
            }
        }
        else
        {
            Debug.Log("ลืมใส่ไรป่าว");
        }

    }

    private void setPoint(List<int> point)
    {
        ShowGraph(point, this.graphVisual, this.maxVisibleValueAmount, this.getAxisLabelX, this.getAxisLabelY);
    }

    private void IncreaseVisibleAmount()
    {
        ShowGraph(this.valueList, this.graphVisual, this.maxVisibleValueAmount + 1, this.getAxisLabelX, this.getAxisLabelY);
    }

    private void DecreaseVisibleAmount()
    {
        ShowGraph(this.valueList, this.graphVisual, this.maxVisibleValueAmount - 1, this.getAxisLabelX, this.getAxisLabelY);
    }

    private void SetGraphVisual(IGraphVisual graphVisual)
    {
        ShowGraph(this.valueList, graphVisual, this.maxVisibleValueAmount, this.getAxisLabelX, this.getAxisLabelY);
    }

    private void ShowGraph(List<int> valueList, IGraphVisual graphVisual , int maxVisibleValueAmount = -1 , Func<int, string> getAxisLabelX = null , Func<float, string> getAxisLabelY = null)
    {
        this.valueList = valueList;
        this.graphVisual = graphVisual;
        this.getAxisLabelX = getAxisLabelX;
        this.getAxisLabelY = getAxisLabelY;

        if(getAxisLabelX == null)
        {
            getAxisLabelX = delegate (int _i) { return _i.ToString(); };
        }
        if (getAxisLabelY == null)
        {
            getAxisLabelY = delegate (float _f) { return Mathf.RoundToInt(_f).ToString(); };
        }
        if(maxVisibleValueAmount <= 0)
        {
            maxVisibleValueAmount = valueList.Count;
        }
        this.maxVisibleValueAmount = maxVisibleValueAmount;

        foreach (GameObject gameObject in gameObjectList)
        {
            Destroy(gameObject);
        }
        gameObjectList.Clear();

        float graphWidth = graphContainer.sizeDelta.x;
        float graphHeight = graphContainer.sizeDelta.y;

        float yMaximum = valueList[0];
        float yMinimum = valueList[0];

        for (int i = Mathf.Max(valueList.Count - maxVisibleValueAmount , 0); i < valueList.Count; i++)
        {
            int value = valueList[i];
            if(value > yMaximum)
            {
                yMaximum = value;
            }
            if(value < yMinimum)
            {
                yMinimum = value;
            }
        }

        float yDifference = yMaximum - yMinimum;
        if(yDifference <=0)
        {
            yDifference = 5f;
        }

        yMaximum = yMaximum + (yDifference * 0.2f);
        yMinimum = yMinimum - (yDifference * 0.2f);

        yMinimum = 0f; //start the graph a 0

        float xSize = graphWidth / (maxVisibleValueAmount + 1);

        int XIndex = 0;


        for(int i = Mathf.Max(valueList.Count - maxVisibleValueAmount, 0); i < valueList.Count; i++)
        {
            float xPosition = xSize + XIndex * xSize;
            float yPosition = ((valueList[i] - yMinimum) / (yMaximum - yMinimum)) * graphHeight;

            gameObjectList.AddRange(graphVisual.AddGraphVisual(new Vector2(xPosition, yPosition), xSize));

            RectTransform labelX = Instantiate(labelTemplateX);
            labelX.SetParent(graphContainer, false);
            labelX.gameObject.SetActive(true);
            labelX.anchoredPosition = new Vector2(xPosition, -27f);
            labelX.GetComponent<Text>().text = getAxisLabelX(i);
            gameObjectList.Add(labelX.gameObject);

            RectTransform dashX = Instantiate(dashTemplateX);
            dashX.SetParent(graphContainer, false);
            dashX.gameObject.SetActive(true);
            dashX.anchoredPosition = new Vector2(xPosition, -7f);
            gameObjectList.Add(dashX.gameObject);

            XIndex++;
        }

        int separatorCount = 10;
        for (int i =0; i <= separatorCount; i++)
        {
            RectTransform labelY = Instantiate(labelTemplateY);
            labelY.SetParent(graphContainer, false);
            labelY.gameObject.SetActive(true);
            float normalizedValue = i * 1f / separatorCount;
            labelY.anchoredPosition = new Vector2(-5f, normalizedValue * graphHeight);
            labelY.GetComponent<Text>().text = getAxisLabelY(yMinimum + (normalizedValue * (yMaximum - yMinimum)));
            gameObjectList.Add(labelY.gameObject);

            RectTransform dashY = Instantiate(dashTemplateY);
            dashY.SetParent(graphContainer, false);
            dashY.gameObject.SetActive(true);
            dashY.anchoredPosition = new Vector2(-4f, normalizedValue * graphHeight);
            gameObjectList.Add(dashY.gameObject);
        }
    }


    private interface IGraphVisual
    {
        List<GameObject> AddGraphVisual(Vector2 graphPosition, float graphPositionWidth);
    }


    private class BarChartVisual : IGraphVisual
    {
        private RectTransform graphContainer;
        private Color barColor;
        private float barWidthMultiplier;

        public BarChartVisual(RectTransform graphContainer, Color barColor , float barWidthMultiplier)
        {
            this.graphContainer = graphContainer;
            this.barColor = barColor;
            this.barWidthMultiplier = barWidthMultiplier;
        }

        public List<GameObject> AddGraphVisual(Vector2 graphPosition, float graphPositionWidth)
        {
            GameObject barGameObject = CreateBar(graphPosition, graphPositionWidth);
            return new List<GameObject>() { barGameObject };
        }

        private GameObject CreateBar(Vector2 graphPosition, float barWidth)
        {
            GameObject gameObject = new GameObject("bar", typeof(Image));
            gameObject.transform.SetParent(graphContainer, false);
            gameObject.GetComponent<Image>().color = barColor;
            RectTransform rectTransform = gameObject.GetComponent<RectTransform>();
            rectTransform.anchoredPosition = new Vector2(graphPosition.x, 0f);
            rectTransform.sizeDelta = new Vector2(barWidth * barWidthMultiplier, graphPosition.y);
            rectTransform.anchorMin = new Vector2(0, 0);
            rectTransform.anchorMax = new Vector2(0, 0);
            rectTransform.pivot = new Vector2(.5f, 0f);
            return gameObject;
        }
    }

    private class LineGraphVisual : IGraphVisual
    {
        private RectTransform graphContainer;
        private Sprite dotSprite;
        private GameObject lastDotGameObject;
        private Color dotColor;
        private Color dotConnectionColor;

        public LineGraphVisual(RectTransform graphContainer, Sprite dotSprite , Color dotColor , Color dotConnectionColor)
        {
            this.graphContainer = graphContainer;
            this.dotSprite = dotSprite;
            this.dotColor = dotColor;
            this.dotConnectionColor = dotConnectionColor;
            lastDotGameObject = null;
        }
        private GameObject CreateDot(Vector2 anchoredPosition)
        {
            GameObject gameObject = new GameObject("dot", typeof(Image));
            gameObject.transform.SetParent(graphContainer, false);
            gameObject.GetComponent<Image>().sprite = dotSprite;
            gameObject.GetComponent<Image>().color = dotColor;
            RectTransform rectTransform = gameObject.GetComponent<RectTransform>();
            rectTransform.anchoredPosition = anchoredPosition;
            rectTransform.sizeDelta = new Vector2(11, 11);
            rectTransform.anchorMin = new Vector2(0, 0);
            rectTransform.anchorMax = new Vector2(0, 0);
            return gameObject;
        }

        public List<GameObject> AddGraphVisual(Vector2 graphPosition, float graphPositionWidth)
        {
            List<GameObject> gameObjectList = new List<GameObject>();
            GameObject dotGameObject = CreateDot(graphPosition);
            gameObjectList.Add(dotGameObject);
            if (lastDotGameObject != null)
            {
                GameObject dotConnectionGameObJect = CreateDotConnection(lastDotGameObject.GetComponent<RectTransform>().anchoredPosition, dotGameObject.GetComponent<RectTransform>().anchoredPosition);
                gameObjectList.Add(dotConnectionGameObJect);
            }
            lastDotGameObject = dotGameObject;
            return gameObjectList;
        }

        private GameObject CreateDotConnection(Vector2 dotPositionA, Vector2 dotPositionB)
        {
            GameObject gameObject = new GameObject("dotConnection", typeof(Image));
            gameObject.transform.SetParent(graphContainer, false);
            gameObject.GetComponent<Image>().color = dotConnectionColor;
            RectTransform rectTransform = gameObject.GetComponent<RectTransform>();
            Vector2 dir = (dotPositionB - dotPositionA).normalized;
            float distance = Vector2.Distance(dotPositionA, dotPositionB);
            rectTransform.anchorMin = new Vector2(0, 0);
            rectTransform.anchorMax = new Vector2(0, 0);
            rectTransform.sizeDelta = new Vector2(distance, 3f);
            rectTransform.anchoredPosition = dotPositionA + dir * distance * .5f;
            rectTransform.localEulerAngles = new Vector3(0, 0, UtilsClass.GetAngleFromVectorFloat(dir));
            return gameObject;
        }
    }
}
