
public class SayaTubeVideo
{
    private int id;
    private string title;
    private int playCount;

    public SayaTubeVideo(string title)
    {
        if (title == null)
        {
            throw new ArgumentException("title null");
        }
        else if (title.Length > 200)
        {
            throw new ArgumentException("sudah melewati batas maksimal");
        }

        this.title = title;
        this.id = new Random().Next(10000, 99999);
        this.playCount = 0;
    }

    public int getPlayCount() { return playCount; }

    public string getTitle() { return title; }

    public void IncreasePlayCount(int count)
    {
        if (count < 0 || count > 25000000)
        {
            throw new ArgumentException("melewati batas");
        }
        try
        {
            checked
            {
                this.playCount += count;
            }
        }
        catch (Exception e)
        {
            throw new OverflowException("telah overflow", e);
        }

    }

    public void PrintVideoDetails()
    {
        Console.WriteLine(this.id);
        Console.WriteLine(this.title);
        Console.WriteLine(this.playCount);
    }
}
public class SayaTubeUser
{
    private int i = 0;
    private int id;
    private List<SayaTubeVideo> uploadedVideos;
    public string Username;

    public SayaTubeUser(string username)
    {
        if (username.Length == null)
        {
            throw new ArgumentException("username null");
        }
        else if (username.Length > 100)
        {
            throw new ArgumentException("username melewati batas");
        }
        this.id = new Random().Next(10000, 99999);
        this.Username = username;
        this.uploadedVideos = [];
    }

    public int GetTotalVideoPlayCount()
    {
        int jumlah = 0;
        for (int i = 0; i < this.uploadedVideos.Count; i++)
        {
            jumlah += uploadedVideos[i].getPlayCount();
        }
        return jumlah;
    }

    public void AddVideo(SayaTubeVideo video)
    {
        this.uploadedVideos.Add(video);
    }

    public void PrintAllVideoPlaycount()
    {
        int no = 1;
        Console.WriteLine("user : " + this.Username);
        for (int j = 0; j < 8; j++)
        {

            Console.WriteLine("Video " + no + " judul: " + this.uploadedVideos[j].getTitle());
            no++;
        }
    }
}

class Program
{
    static void Main(string[] args)
    {
        try
        {
            SayaTubeUser user = new SayaTubeUser("Farid");
            SayaTubeVideo video1 = new SayaTubeVideo("Breaking Bad");
            SayaTubeVideo video2 = new SayaTubeVideo("Better Call Saul");
            SayaTubeVideo video3 = new SayaTubeVideo("Fight Club");
            SayaTubeVideo video4 = new SayaTubeVideo("El Camino");
            SayaTubeVideo video5 = new SayaTubeVideo("Tengen Toppa Gurren Lagann");
            SayaTubeVideo video6 = new SayaTubeVideo("Bleach");
            SayaTubeVideo video7 = new SayaTubeVideo("Koe no Katachi");
            SayaTubeVideo video8 = new SayaTubeVideo("Dragon Ball");
            SayaTubeVideo video9 = new SayaTubeVideo("Death note");
            SayaTubeVideo video10 = new SayaTubeVideo("kok");

            user.AddVideo(video1);
            user.AddVideo(video2);
            user.AddVideo(video3);
            user.AddVideo(video4);
            user.AddVideo(video5);
            user.AddVideo(video6);
            user.AddVideo(video7);
            user.AddVideo(video8);
            user.AddVideo(video9);
            user.AddVideo(video10);

            user.PrintAllVideoPlaycount();

            for (int i = 0; i < 10000000000; i++)
            {
                video1.IncreasePlayCount(i);
            }

        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}