using System.Collections;
using UnityEngine;

public class EffectManager : MonoBehaviour
{
    [SerializeField] private ObjectPool signBoardEffectPool;
    [SerializeField] private ObjectPool special1EffectPool;
    [SerializeField] private ObjectPool special2EffectPool;
    [SerializeField] private ObjectPool rivalSpecial1EffectPool;
    [SerializeField] private ObjectPool rivalSpecial2EffectPool;
    [SerializeField] private ObjectPool establishmentEffectPool;
    [SerializeField] private ObjectPool shatihokoEffect1Pool;
    [SerializeField] private ObjectPool shatihokoEffect2Pool;
    [SerializeField] private ObjectPool shatihokoEffect3Pool;
    [SerializeField] private ObjectPool shatihokoEffect4Pool;
    [SerializeField] private ObjectPool increaseOfCapitalEffectPool;

    public ObjectPool SignBoardEffectPool => signBoardEffectPool;
    public ObjectPool Special1EffectPool => special1EffectPool;
    public ObjectPool Special2EffectPool => special2EffectPool;
    public ObjectPool RivalSpecial1EffectPool => rivalSpecial1EffectPool;
    public ObjectPool RivalSpecial2EffectPool => rivalSpecial2EffectPool;
    public ObjectPool EstablishEffectPool => establishmentEffectPool;
    public ObjectPool ShatihokoEffect1Pool => shatihokoEffect1Pool;
    public ObjectPool ShatihokoEffect2Pool => shatihokoEffect2Pool;
    public ObjectPool ShatihokoEffect3Pool => shatihokoEffect3Pool;
    public ObjectPool ShatihokoEffect4Pool => shatihokoEffect4Pool;
    public ObjectPool IncreaseOfCapitalEffectPool => increaseOfCapitalEffectPool;

    // エフェクトを呼び出し、その後戻す
    public GameObject SpawnSignBoardEffect(Vector3 position)
    {
        GameObject fireEffect = signBoardEffectPool.GetEffect(position, Quaternion.identity);
        StartCoroutine(ReturnSignBoardEffectAfterTime(fireEffect, 1f)); // 例: 2秒後にエフェクトをプールに戻す
        return fireEffect;
    }

    // エフェクトをプールに戻す
    private IEnumerator ReturnSignBoardEffectAfterTime(GameObject effect, float time)
    {
        yield return new WaitForSeconds(time);  // 例えば2秒後にエフェクトを戻す
        signBoardEffectPool.ReturnEffect(effect);
    }

    // エフェクトを呼び出し、その後戻す
    public GameObject SpawnSpecial1Effect(Vector3 position)
    {
        GameObject fireEffect = special1EffectPool.GetEffect(position, Quaternion.identity);
        StartCoroutine(ReturnSpecial1EffectAfterTime(fireEffect, 5f)); // 例: 5秒後にエフェクトをプールに戻す
        return fireEffect;
    }

    // エフェクトをプールに戻す
    private IEnumerator ReturnSpecial1EffectAfterTime(GameObject effect, float time)
    {
        yield return new WaitForSeconds(time);  // 例えば5秒後にエフェクトを戻す
        special1EffectPool.ReturnEffect(effect);
    }

    // エフェクトを呼び出し、その後戻す
    public GameObject SpawnSpecial2Effect(Vector3 position)
    {
        GameObject fireEffect = special2EffectPool.GetEffect(position, Quaternion.identity);
        StartCoroutine(ReturnSpecial2EffectAfterTime(fireEffect, 5f)); // 例: 5秒後にエフェクトをプールに戻す
        return fireEffect;
    }

    // エフェクトをプールに戻す
    private IEnumerator ReturnSpecial2EffectAfterTime(GameObject effect, float time)
    {
        yield return new WaitForSeconds(time);  // 例えば5秒後にエフェクトを戻す
        special2EffectPool.ReturnEffect(effect);
    }

    // エフェクトを呼び出し、その後戻す
    public GameObject SpawnRivalSpecial1Effect(Vector3 position)
    {
        GameObject fireEffect = rivalSpecial1EffectPool.GetEffect(position, Quaternion.identity);
        StartCoroutine(ReturnRivalSpecial1EffectAfterTime(fireEffect, 5f)); // 例: 5秒後にエフェクトをプールに戻す
        return fireEffect;
    }

    // エフェクトをプールに戻す
    private IEnumerator ReturnRivalSpecial1EffectAfterTime(GameObject effect, float time)
    {
        yield return new WaitForSeconds(time);  // 例えば5秒後にエフェクトを戻す
        rivalSpecial1EffectPool.ReturnEffect(effect);
    }

    public GameObject SpawnRivalSpecial2Effect(Vector3 position)
    {
        GameObject fireEffect = rivalSpecial2EffectPool.GetEffect(position, Quaternion.identity);
        StartCoroutine(ReturnRivalSpecial2EffectAfterTime(fireEffect, 5f)); // 例: 5秒後にエフェクトをプールに戻す
        return fireEffect;
    }

    // エフェクトをプールに戻す
    private IEnumerator ReturnRivalSpecial2EffectAfterTime(GameObject effect, float time)
    {
        yield return new WaitForSeconds(time);  // 例えば5秒後にエフェクトを戻す
        rivalSpecial2EffectPool.ReturnEffect(effect);
    }

    // エフェクトを呼び出し、その後戻す
    public GameObject SpawnEstablishEffect(Vector3 position)
    {
        GameObject fireEffect = establishmentEffectPool.GetEffect(position, Quaternion.identity);
        StartCoroutine(ReturnEstablishEffectAfterTime(fireEffect, 1f)); // 例: 1秒後にエフェクトをプールに戻す
        return fireEffect;
    }

    // エフェクトをプールに戻す
    private IEnumerator ReturnEstablishEffectAfterTime(GameObject effect, float time)
    {
        yield return new WaitForSeconds(time);  // 例えば1秒後にエフェクトを戻す
        establishmentEffectPool.ReturnEffect(effect);
    }

    public GameObject SpawnShatihokoEffect1(Vector3 position)
    {
        GameObject fireEffect = shatihokoEffect1Pool.GetEffect(position, Quaternion.identity);
        StartCoroutine(ReturnShatihokoEffect1AfterTime(fireEffect, 8f)); // 例: 3秒後にエフェクトをプールに戻す
        return fireEffect;
    }

    // エフェクトをプールに戻す
    private IEnumerator ReturnShatihokoEffect1AfterTime(GameObject effect, float time)
    {
        yield return new WaitForSeconds(time);  // 例えば3秒後にエフェクトを戻す
        shatihokoEffect1Pool.ReturnEffect(effect);
    }

    // エフェクトを呼び出し、その後戻す
    public GameObject SpawnShatihokoEffect2(Vector3 position)
    {
        GameObject fireEffect = shatihokoEffect2Pool.GetEffect(position, Quaternion.identity);
        StartCoroutine(ReturnShatihokoEffect2AfterTime(fireEffect, 10f)); // 例: 3秒後にエフェクトをプールに戻す
        return fireEffect;
    }

    // エフェクトをプールに戻す
    private IEnumerator ReturnShatihokoEffect2AfterTime(GameObject effect, float time)
    {
        yield return new WaitForSeconds(time);  // 例えば3秒後にエフェクトを戻す
        shatihokoEffect2Pool.ReturnEffect(effect);
    }

    // エフェクトを呼び出し、その後戻す
    public GameObject SpawnShatihokoEffect3(Vector3 position)
    {
        GameObject fireEffect = shatihokoEffect3Pool.GetEffect(position, Quaternion.identity);
        StartCoroutine(ReturnShatihokoEffect3AfterTime(fireEffect, 10f)); // 例: 3秒後にエフェクトをプールに戻す
        return fireEffect;
    }

    // エフェクトをプールに戻す
    private IEnumerator ReturnShatihokoEffect3AfterTime(GameObject effect, float time)
    {
        yield return new WaitForSeconds(time);  // 例えば3秒後にエフェクトを戻す
        shatihokoEffect3Pool.ReturnEffect(effect);
    }

    // エフェクトを呼び出し、その後戻す
    public GameObject SpawnShatihokoEffect4(Vector3 position)
    {
        GameObject fireEffect = shatihokoEffect4Pool.GetEffect(position, Quaternion.identity);
        StartCoroutine(ReturnShatihokoEffect4AfterTime(fireEffect, 8f)); // 例: 3秒後にエフェクトをプールに戻す
        return fireEffect;
    }

    // エフェクトをプールに戻す
    private IEnumerator ReturnShatihokoEffect4AfterTime(GameObject effect, float time)
    {
        yield return new WaitForSeconds(time);  // 例えば3秒後にエフェクトを戻す
        shatihokoEffect4Pool.ReturnEffect(effect);
    }

    // エフェクトを呼び出し、その後戻す
    public GameObject SpawnIncreaseOfCapitalEffect(Vector3 position)
    {
        GameObject fireEffect = increaseOfCapitalEffectPool.GetEffect(position, Quaternion.identity);
        StartCoroutine(ReturnIncreaseOfCapitalEffectAfterTime(fireEffect, 2.5f)); // 例: 2.5秒後にエフェクトをプールに戻す
        return fireEffect;
    }

    // エフェクトをプールに戻す
    private IEnumerator ReturnIncreaseOfCapitalEffectAfterTime(GameObject effect, float time)
    {
        yield return new WaitForSeconds(time);  // 例えば2.5秒後にエフェクトを戻す
        increaseOfCapitalEffectPool.ReturnEffect(effect);
    }
}
