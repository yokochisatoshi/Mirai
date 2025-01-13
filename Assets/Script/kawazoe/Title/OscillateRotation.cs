using UnityEngine;

public class OscillateRotation : MonoBehaviour
{
    private float startZAngle; // ‰ñ“]‚ÌŠî€Šp“x
    private bool rotatingToPositive = true; // ³‚Ì•ûŒü‚É‰ñ“]‚µ‚Ä‚¢‚é‚©‚Ç‚¤‚©
    public float rotationSpeed = 50f; // ‰ñ“]‘¬“x (“x/•b)
    public float rotationLimit = 50f; // ‰ñ“]”ÍˆÍ‚ÌŒÀŠE (}50“x)

    void Start()
    {
        // ‰Šú‚ÌZ²‰ñ“]Šp“x‚ğæ“¾
        startZAngle = transform.eulerAngles.z;
    }

    void Update()
    {
        // Œ»İ‚ÌŠp“x‚ğæ“¾
        float currentZAngle = transform.eulerAngles.z;

        // Unity‚Ì‰ñ“]‚Í360“x§ŒÀ‚ª‚ ‚é‚½‚ßAŠp“x‚ğ-180“x‚©‚ç180“x‚É•ÏŠ·
        currentZAngle = NormalizeAngle(currentZAngle);

        // Šî€Šp“x‚Æ‚Ì·•ª‚ğŒvZ
        float deltaAngle = currentZAngle - startZAngle;

        // ‰ñ“]•ûŒü‚Ì”»’è
        if (rotatingToPositive && deltaAngle >= rotationLimit)
        {
            rotatingToPositive = false; // •‰‚Ì•ûŒü‚ÉØ‚è‘Ö‚¦‚é
        }
        else if (!rotatingToPositive && deltaAngle <= -rotationLimit)
        {
            rotatingToPositive = true; // ³‚Ì•ûŒü‚ÉØ‚è‘Ö‚¦‚é
        }

        // ‰ñ“]‚ğ“K—p
        float rotationStep = rotationSpeed * Time.deltaTime;
        if (!rotatingToPositive) rotationStep = -rotationStep;

        transform.Rotate(0, 0, rotationStep);
    }

    // Šp“x‚ğ-180“x`180“x‚Ì”ÍˆÍ‚É³‹K‰»
    private float NormalizeAngle(float angle)
    {
        while (angle > 180f) angle -= 360f;
        while (angle < -180f) angle += 360f;
        return angle;
    }
}
