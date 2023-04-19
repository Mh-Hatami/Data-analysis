using Data_analysis.Model;
Mathckecker mathckecker = new Mathckecker();
string filePath = @"D:\Data\orders.csv";
List<Digikala> odigikala = new List<Digikala>();
List<string> cities = new List<string>();
string line;
using (StreamReader sr = new StreamReader(filePath))
{
    sr.ReadLine();
    while (!sr.EndOfStream)
    {
        line = sr.ReadLine();
        Digikala digikala = new Digikala();

        digikala.Id_Order = Convert.ToInt32(line.Split(",")[0]);
        digikala.Id_Customer = Convert.ToInt32(line.Split(",")[1]);
        digikala.Id_Item = Convert.ToInt32(line.Split(",")[2]);
        digikala.DateTime_CartFinalize = (line.Split(",")[3]);
        digikala.Amount_Gross_Order = Convert.ToInt32(line.Split(",")[4].Replace(".0", ""));
        digikala.City_name_fa = (line.Split(",")[5]);

        odigikala.Add(digikala);
        cities.Add(digikala.City_name_fa);
        cities = cities.Distinct().ToList();
    }
}

//ریختن یوزر آیدی های ((فرد)) درون یک فایل:////////////////////////////
List<int> userIds = new List<int>();
foreach (var item in odigikala)
{
    if (mathckecker.IsOdd(item.Id_Customer))
    {
        userIds.Add(item.Id_Customer);
    }
}
// تبدیل لیست به رشته جدا شده با کاراکتر جدید
string outputString = string.Join(Environment.NewLine, userIds);
// نوشتن رشته خروجی در فایل
string outputFilePath1 = @"D:\Data\output-odd.txt";
using (StreamWriter sw = new StreamWriter(outputFilePath1))
{
    sw.WriteLine("Odd Customer_Id");
    sw.Write(outputString);
}
////////////////////////////////////////////////////////////////////

//ریختن یوزر آیدی های ((اول)) درون یک فایل:////////////////////////////
List<int> userIds2 = new List<int>();
foreach (var item in odigikala)
{
    if (mathckecker.IsPrime(item.Id_Customer))
    {
        userIds2.Add(item.Id_Customer);
    }
}
// تبدیل لیست به رشته جدا شده با کاراکتر جدید
string outputString2 = string.Join(Environment.NewLine, userIds2);
// نوشتن رشته خروجی در فایل
string outputFilePath2 = @"D:\Data\output-prime.txt";
using (StreamWriter sw = new StreamWriter(outputFilePath2))
{
    sw.WriteLine("Prime Customer_Id");
    sw.Write(outputString2);
}
///////////////////////////////////////////////////////////////////

//ریختن یوزر آیدی های ((آیینه ای)) درون یک فایل:////////////////////////
List<int> userIds3 = new List<int>();
foreach (var item in odigikala)
{
    if (mathckecker.Ismirror(item.Id_Customer))
    {
        userIds3.Add(item.Id_Customer);
    }
}
// تبدیل لیست به رشته جدا شده با کاراکتر جدید
string outputString3 = string.Join(Environment.NewLine, userIds3);
// نوشتن رشته خروجی در فایل
string outputFilePath3 = @"D:\Data\output-mirror.txt";
using (StreamWriter sw = new StreamWriter(outputFilePath3))
{
    sw.WriteLine("Mirror Customer_Id");
    sw.Write(outputString3);
}
////////////////////////////////////////////////////////////////////////


//// cities translate
///تبدیل لیست شهرها به لیست شهرهای یکتا (حذف نام شهرهای تکراری)و ریختن آنها درون یک فایل برای استفاده ی ترنسلیتور 
Dictionary<string, int> cityCount = new Dictionary<string, int>();
foreach (string city in cities)
{
    if (!cityCount.ContainsKey(city))
    {
        cityCount[city] = 1;
    }
    else
    {
        cityCount[city]++;
    }
}
List<string> uniqueCities = cityCount.Keys.ToList();
string outputFilePath = @"D:\Data\unique_cities_en.csv";
using (StreamWriter sw = new StreamWriter(outputFilePath))
{
    sw.WriteLine("Cities english Name");
    foreach (string city in uniqueCities)
    {
        string en_city = city.Replace("آ", "A").Replace("ا", "a").Replace("ب", "b").Replace("پ", "p").Replace("ت", "t").Replace("ث", "s")
            .Replace("ج", "j").Replace("چ", "ch").Replace("ح", "h").Replace("خ", "kh").Replace("د", "d").Replace("ذ", "z")
            .Replace("ر", "r").Replace("ز", "z").Replace("ژ", "zh").Replace("س", "s").Replace("ش", "sh").Replace("ص", "s")
            .Replace("ض", "z").Replace("ط", "t").Replace("ظ", "z").Replace("ع", "").Replace("غ", "gh").Replace("ف", "f")
            .Replace("ق", "gh").Replace("ک", "k").Replace("گ", "g").Replace("ل", "l").Replace("م", "m").Replace("ن", "n")
            .Replace("و", "v").Replace("ۀ", "e").Replace("ه", "h").Replace("ی", "i").Replace("ئ", "e");
        sw.WriteLine(en_city);
    }
}


class Mathckecker
{
    public bool IsOdd(int number)
    {
        if (number % 2 == 0)
        {
            return false;
        }
        return true;
    }
    public bool IsPrime(int number)
    {
        if (number <= 1)
        {
            return false;
        }

        for (int i = 2; i <= Math.Sqrt(number); i++)
        {
            if (number % i == 0)
            {
                return false;
            }
        }

        return true;
    }
    public bool Ismirror(int number)
    {
        int originalNumber = number;
        int reversedNumber = 0;

        while (number > 0)
        {
            int digit = number % 10;
            reversedNumber = (reversedNumber * 10) + digit;
            number /= 10;
        }

        return originalNumber == reversedNumber;
    }
}
