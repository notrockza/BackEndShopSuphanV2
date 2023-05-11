namespace ShopSuphan.Models.OrderAggregate
{
    public enum Paymentstatus
    {
        WaitingForPayment, // กำลังรอการชำระเงิน
        PendingApproval, // รอการอนุมัติ
        SuccessfulPayment // ชำระเงินสำเร็จ
    }
}
