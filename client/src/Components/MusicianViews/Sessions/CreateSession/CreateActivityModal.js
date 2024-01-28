import React, { useEffect, useState } from 'react';
import { Button, Modal, ModalHeader, ModalBody, ModalFooter } from 'reactstrap';
import { getcategoryById } from '../../../../Managers/categoryManager';
import { postNewActivity } from '../../../../Managers/activityManager';

export const CreateActivityModal = ({categoryId, getAndSetActivities, loggedInUser}) => {
    const [modal, setModal] = useState(false);
    const [category, setCategory] = useState({});
    const [newActivity, setNewActivity] = useState({
        name:"",
        details: "",
        categoryId: categoryId,
        creatorId: loggedInUser.id
    });

    useEffect(() => {if(categoryId > 0) {getAndSetCategory(categoryId)} }, [categoryId]);

    const toggleModal = () => {
        setModal(!modal)
    };

    const getAndSetCategory = (categoryId) => {
        getcategoryById(categoryId).then(setCategory);
    }

    const handleSubmit = async (e) => {
        e.preventDefault();
        await postNewActivity(newActivity)
        await getAndSetActivities(categoryId)
        setNewActivity({
          name:"",
          details: "",
          categoryId: categoryId,
          creatorId: loggedInUser?.id
        })
        toggleModal();
    }

    return (
    <div>
      <Button id="create-activity-btn" className="create-btn" color='info' size='sm' onClick={toggleModal}>
        Create New Activity
      </Button>
      <Modal isOpen={modal} toggle={toggleModal} style={{color:'black'}} backdrop="static">
        <ModalHeader toggle={toggleModal}>
            Add to category:{" "}{category.name}
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
          {newActivity.name && newActivity.details ? 
          <Button color="secondary" onClick={(e) => handleSubmit(e)}>
            Create Activity
          </Button> : null}
        </ModalFooter>
      </Modal>
    </div>
  );
}