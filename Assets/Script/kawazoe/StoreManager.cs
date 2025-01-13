using UnityEngine;

public class StoreManager : MonoBehaviour
{
    public Vector3 scaleIncrease; // Šg‘åƒTƒCƒY

    public GameObject MisokatuModel;
    public GameObject UirouModel;
    public GameObject HitsumabushiModel;
    public GameObject TebasakiModel;
    public GameObject TaiwanRamenModel;
    public GameObject KishimenModel;

    // –¡‘XƒJƒc“X‘‘
    public void OperateMisokatuScaleIncrease()
    {
        Debug.Log("Misokatu‚ğ‘‘‚µ‚Ü‚·");

        Vector3 newScale = MisokatuModel.transform.localScale + scaleIncrease;
        MisokatuModel.transform.localScale = newScale;

        SoundManager.Instance.PlaySound("Applause"); 
        SoundManager.Instance.PlaySound("IncreaseOfCapital");
    }

    // –¡‘XƒJƒc“X•KE‹Z
    public void OperateMisokatuSpecial()
    {
        Debug.Log("Misokatu‚ª•KE‹Z‚ğg‚¢‚Ü‚·");
        MisokatuModel.GetComponent<Store>().UseSkill();
    }

    // ‚¤‚¢‚ë‚¤“X‘‘
    public void OperateUirouScaleIncrease()
    {
        Debug.Log("Uirou‚ğ‘‘‚µ‚Ü‚·");

        Vector3 newScale = UirouModel.transform.localScale + scaleIncrease;
        UirouModel.transform.localScale = newScale;

        SoundManager.Instance.PlaySound("Applause");
        SoundManager.Instance.PlaySound("IncreaseOfCapital");
    }

    // ‚¤‚¢‚ë‚¤“X•KE‹Z
    public void OperateUirouSpecial()
    {
        Debug.Log("Uirou‚ª•KE‹Z‚ğg‚¢‚Ü‚·");
        UirouModel.GetComponent<Store>().UseSkill();
    }

    // ‚Ğ‚Â‚Ü‚Ô‚µ“X‘‘
    public void OperateHitshmabushiScaleIncrease()
    {
        Debug.Log("Hitsumabushi‚ğ‘‘‚µ‚Ü‚·");

        Vector3 newScale = HitsumabushiModel.transform.localScale + scaleIncrease;
        HitsumabushiModel.transform.localScale = newScale;

        SoundManager.Instance.PlaySound("Applause");
        SoundManager.Instance.PlaySound("IncreaseOfCapital");
    }

    // ‚Ğ‚Â‚Ü‚Ô‚µ“X•KE‹Z
    public void OperateHitshmabushiSpecial()
    {
        Debug.Log("Hitsumabushi‚ª•KE‹Z‚ğg‚¢‚Ü‚·");
        HitsumabushiModel.GetComponent<Store>().UseSkill();
    }

    // è‰Hæ“X‘‘
    public void OperateTebasakiScaleIncrease()
    {
        Debug.Log("TebasakiModel‚ğ‘‘‚µ‚Ü‚·");

        Vector3 newScale = TebasakiModel.transform.localScale + scaleIncrease;
        TebasakiModel.transform.localScale = newScale;

        SoundManager.Instance.PlaySound("Applause");
        SoundManager.Instance.PlaySound("IncreaseOfCapital");
    }

    // è‰Hæ“X•KE‹Z
    public void OperateTebasakiSpecial()
    {
        Debug.Log("TebasakiModel‚ª•KE‹Z‚ğg‚¢‚Ü‚·");
        TebasakiModel.GetComponent<Store>().UseSkill();
    }

    // ‘ä˜pƒ‰[ƒƒ““X‘‘
    public void OperateTaiwanRamenScaleIncrease()
    {
        Debug.Log("TaiwanRamen‚ğ‘‘‚µ‚Ü‚·");

        Vector3 newScale = TaiwanRamenModel.transform.localScale + scaleIncrease;
        TaiwanRamenModel.transform.localScale = newScale;

        SoundManager.Instance.PlaySound("Applause");
        SoundManager.Instance.PlaySound("IncreaseOfCapital");
    }

    // ‘ä˜pƒ‰[ƒƒ““X•KE‹Z
    public void OperateTaiwanRamenSpecial()
    {
        Debug.Log("TaiwanRamen‚ª•KE‹Z‚ğg‚¢‚Ü‚·");
        TaiwanRamenModel.GetComponent<Store>().UseSkill();
    }

    // ‚«‚µ‚ß‚ñ“X‘‘
    public void OperateKishimenScaleIncrease()
    {
        Debug.Log("Kishimen‚ğ‘‘‚µ‚Ü‚·");

        Vector3 newScale = KishimenModel.transform.localScale + scaleIncrease;
        KishimenModel.transform.localScale = newScale;

        SoundManager.Instance.PlaySound("Applause");
        SoundManager.Instance.PlaySound("IncreaseOfCapital");
    }

    // ‚«‚µ‚ß‚ñ“X•KE‹Z
    public void OperateKishimenSpecial()
    {
        Debug.Log("Kishimen‚ª•KE‹Z‚ğg‚¢‚Ü‚·");
        KishimenModel.GetComponent<Store>().UseSkill();
    }
}
