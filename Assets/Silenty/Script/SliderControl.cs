using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class SliderControl : MonoBehaviour
{
	public Sprite lightPoint;
	public Sprite darkPoint;
	public Image onePoint;
	public Image twoPoint;
	public Image threePoint;

    public Scrollbar m_Scrollbar;
    public ScrollRect m_ScrollRect;

    private float mTargetValue;

    private bool mNeedMove = false;

    private const float MOVE_SPEED = 1F;

    private const float SMOOTH_TIME = 0.2F;

    private float mMoveSpeed = 0f;

    public void OnPointerDown()
    {
        mNeedMove = false;
    }

    public void OnPointerUp()
    {
        // 判断当前位于哪个区间，设置自动滑动至的位置
        if (m_Scrollbar.value <= 0.167f)
        {
            mTargetValue = 0;
			onePoint.sprite = lightPoint;
			twoPoint.sprite = darkPoint;
			threePoint.sprite = darkPoint;
        }
        else if (m_Scrollbar.value <= 0.8f)
        {
            mTargetValue = 0.5f;
			onePoint.sprite = darkPoint;
			twoPoint.sprite = lightPoint;
			threePoint.sprite = darkPoint;
        }
        else
        {
            mTargetValue = 1f;
			onePoint.sprite = darkPoint;
			twoPoint.sprite = darkPoint;
			threePoint.sprite = lightPoint;
        }

        mNeedMove = true;
        mMoveSpeed = 0;
    }

    public void OnButtonClick()
    {
		OnPointerUp ();
    }

    void Update()
    {
        if (mNeedMove)
        {
            if (Mathf.Abs(m_Scrollbar.value - mTargetValue) < 0.01f)
            {
                m_Scrollbar.value = mTargetValue;
                mNeedMove = false;
                return;
            }
            m_Scrollbar.value = Mathf.SmoothDamp(m_Scrollbar.value, mTargetValue, ref mMoveSpeed, SMOOTH_TIME);
        }
    }

}
