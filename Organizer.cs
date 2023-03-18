using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TaskbarClock;

namespace Organizer
{
    public class Organizer
    {
        public List<Data> list = new List<Data>();

        public Organizer(Data data)
        {
            list.Add(data);
        }

        public Organizer()
        {

        }

        public void add(Data data)
        {
            this.list.Add(data);
        }

        public void remove(int index)
        {
            if (index < list.Count)
            {
                list.RemoveAt(index);
            }
        }

        public List<Data> findByTime(string time)
        {
            List<Data> tmplist = new List<Data>();
            list.ForEach(item =>
            {
                int time1 = item.Time.Hours * 3600 + item.Time.Minutes;
                int time2 = int.Parse(time.Split(':')[0]) * 3600 + int.Parse(time.Split(':')[0]);
                if (time2 >= time1)
                {
                    tmplist.Add(item);
                }
            });
            return tmplist;
        }

        public List<Data> findByCategory(EventType type)
        {
            List<Data> tmplist = new List<Data>();
            list.ForEach(item =>
            {
                if (item.eventType == type)
                {
                    tmplist.Add(item);
                }
            });
            return tmplist;
        }

        public List<Data> findByText(string text)
        {
            List<Data> tmplist = new List<Data>();
            list.ForEach(item =>
            {
                if (item.Event.IndexOf(text)>=0)
                {
                    tmplist.Add(item);
                }
            });
            return tmplist;
        }



        public void sortByTime(int direction = 0)
        {
            list.Sort((x, y) => {
                int timeX = x.Time.Hours * 3600 + x.Time.Minutes;
                int timeY = y.Time.Hours * 3600 + y.Time.Minutes;
                
                if (direction == 0)
                {
                    if (timeX > timeY)
                        return 1;
                    if (timeX < timeY)
                        return -1;
                    if (timeX == timeY)
                        return 0;
                }

                if (direction == 1)
                {
                    if (timeX > timeY)
                        return -1;
                    if (timeX < timeY)
                        return 1;
                    if (timeX == timeY)
                        return 0;
                }
                return 0;
            }
            );
        }
    }
}
