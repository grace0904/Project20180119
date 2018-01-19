
namespace InkeServer.Enums
{
    /// <summary>
    /// 返回值说明
    /// </summary>
    public enum ResultCode : int
    {
        /// <summary>
        /// 操作成功
        /// </summary>
        Complete = 200,
        /// <summary>
        /// 非预期异常
        /// </summary>
        Unexpected = 10001,
        /// <summary>
        /// 缺少必要参数
        /// </summary>
        ArgumentsMiss = 10002,
        /// <summary>
        /// 签名校验错误
        /// </summary>
        SignInvalid = 10010,
        /// <summary>
        /// 操作失败
        /// </summary>
        OperationFaild = 10011,
        /// <summary>
        /// 数据库错误
        /// </summary>
        DBError = 20010,
        /// <summary>
        /// 没有相应的记录
        /// </summary>
        DataNotFound = 20012,
        /// <summary>
        /// 记录已存在
        /// </summary>
        DataRepeated = 20013,
        /// <summary>
        /// 更新失败
        /// </summary>
        UpdateFaild = 20014,
        /// <summary>
        /// 添加失败
        /// </summary>
        AddFaild = 20015,
        /// <summary>
        /// 删除失败
        /// </summary>
        DeleteFaild = 20016,
        /// <summary>
        /// 名称已存在
        /// </summary>
        NameExisted = 20019,
        /// <summary>
        /// 产品已存在或超出套餐最大数量
        /// </summary>
        ProductExistedOrNumExceeded = 20021,
        /// <summary>
        /// 编码已存在
        /// </summary>
        CodeExisted = 20030,
        /// <summary>
        /// 存在产品属于套餐产品,请先删除套餐下的该产品
        /// </summary>
        ProductComboHasProduct = 20031,
        /// <summary>
        /// 存在产品,正被店铺使用,请先删除店铺产品
        /// </summary>
        ProductComboUsed = 20032,
        /// <summary>
        /// 存在套餐组,正被产品使用,请先删除产品
        /// </summary>
        ProductComboGroupUsed = 20036,
        /// <summary>
        /// 不支持的扩展名类型
        /// </summary>
        ExtensionTypeNotSupported = 20035,
        /// <summary>
        /// 原始密码不正确
        /// </summary>
        OldPasswordWrong = 30011,
        /// <summary>
        /// 商家编号不正确
        /// </summary>
        MerhcantCodeWrong = 30012,
        /// <summary>
        /// 登录失败
        /// </summary>
        LoginFaild = 30013,
        /// <summary>
        /// 登录失败(不允许登录CRM)
        /// </summary>
        NotLoginCRM = 30014,
        /// <summary>
        /// 登录失败(不允许登录POS)
        /// </summary>
        NotLoginPOS = 30015,
        /// <summary>
        /// 登录失败(不允许登录KFT)
        /// </summary>
        NotLoginKFT = 30016,
        /// <summary>
        /// 统计时间间隔不能少于1
        /// </summary>
        EimeIntervalLessThan1 = 30021,
        /// <summary>
        /// 密码不正确
        /// </summary>
        PasswordWrong = 30017,
        /// <summary>
        /// 帐号不存在
        /// </summary>
        AccountInexistence = 30018,
        /// <summary>
        /// 营销方案的赠送优惠券中存在已过期优惠券
        /// </summary>
        GiveCouponOverdue = 30022,
        /// <summary>
        /// 登录失败(不允许登录INPOS)
        /// </summary>
        NotLoginINPOS = 30023,
    }
}
