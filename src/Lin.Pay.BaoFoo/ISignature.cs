namespace Lin.Pay.BaoFoo;

public interface ISignature
{
    
    /// <summary>
    /// 获取签名数据
    /// </summary>
    /// <returns></returns>
    string GetSignFieldString();

}