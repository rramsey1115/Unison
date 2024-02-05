import React, { useEffect, useState } from 'react';
import { Button, Modal, ModalHeader, ModalBody, ModalFooter } from 'reactstrap';
import "./Browse.css";
import { getActivityById, updateActivity } from '../../../Managers/activityManager';

export const EditActivityModal = ({activityId, categoryId, getAndSetActivitiesByCategoryId}) => {
    const [modal, setModal] = useState(false);
    const [activity, setActivity] = useState({});
    const [newActivity, setNewActivity] = useState({});

    useEffect(() => { getAndSetActivity(activityId) }, [activityId]);

    useEffect(() => {
        if(activity) { setNewActivity({
            id: activityId,
            name:activity.name,
            details: activity.details})}
    }, [activity]);

    const getAndSetActivity = () => {
        getActivityById(activityId).then(setActivity);
    }

    const toggleModal = () => {
        setModal(!modal)
    };

    const handleSubmit = async (e) => {
        e.preventDefault();
        await updateActivity(newActivity);
        await getAndSetActivitiesByCategoryId(categoryId);
        toggleModal();
    }

    return (
    <div>
      <Button id="edit-category-btn" className="edit-activity-btn" color='info' size='sm' onClick={toggleModal}>
        Edit
      </Button>
      <Modal isOpen={modal} toggle={toggleModal} style={{color:'black'}} backdrop="static">
        <ModalHeader toggle={toggleModal}>
            Edit Activity:{" "}
            {newActivity.name}
        </ModalHeader>
        <ModalBody className='modal-body'>
            
            <input
                id='activity-name-input'
                value={newActivity.name}
                type='text'
                placeholder='Activity Name'
                onChange={(e) => {
                    const copy = {...newActivity};
                    copy.name = e.target.value;
                    setNewActivity(copy);
                }}
            />

            <textarea
                id='activity-details-input'
                value={newActivity.details}
                type='text'
                placeholder='Activity Description'
                onChange={(e) => {
                    const copy = {...newActivity};
                    copy.details = e.target.value;
                    setNewActivity(copy);
                }}
            />

        </ModalBody>
        <ModalFooter>
          <Button color="secondary" onClick={(e) => handleSubmit(e)}>
            Save
          </Button>
        </ModalFooter>
      </Modal>
    </div>
  );
}