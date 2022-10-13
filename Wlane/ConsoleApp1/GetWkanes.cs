using NativeWifi;
using System.Text;


namespace ConsoleApp1;

public class GetWkanes
{
    public List<Wlan.WlanAvailableNetwork> GetWlanec()
    {
        List<Wlan.WlanAvailableNetwork> getWlanes = new List<Wlan.WlanAvailableNetwork>();
        WlanClient client = new ();
        foreach (WlanClient.WlanInterface wlan in client.Interfaces)
        {
            wlan.Scan();
            Wlan.WlanAvailableNetwork[] networks = wlan.GetAvailableNetworkList(0);
            foreach (Wlan.WlanAvailableNetwork network in networks)
            {
                getWlanes.Add(network);
            }
        }
        return getWlanes;
    }

    public List<string> GetWlanecString()
    {
        List<string> getWlanes = new List<string>();
        WlanClient client = new();
        foreach (WlanClient.WlanInterface wlan in client.Interfaces)
        {
            wlan.Scan();
            Wlan.WlanAvailableNetwork[] networks = wlan.GetAvailableNetworkList(0);
            foreach (Wlan.WlanAvailableNetwork network in networks)
            {
                string ssid = Encoding.Default.GetString(network.dot11Ssid.SSID);
                getWlanes.Add(ssid);
            }
        }
        return getWlanes;
    }

}