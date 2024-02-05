import React, { useEffect, useState } from 'react';
import { Button, Modal, ModalHeader, ModalBody, ModalFooter } from 'reactstrap';
import "./Profile.css";
import { getUsersWithRoles, updateUserProfile } from '../../../Managers/profileManager';

export const EditProfileModal = ({ user, loggedInUser, getAndSetUser}) => {
    const [modal, setModal] = useState(false);
    const [updatedUser, setUpdatedUser] = useState({});
    const [teachers, setTeachers] = useState([]);

    useEffect(() => {
        if(user.id)
        {
            setUpdatedUser({
                id: user.id,
                identityUserId: user.identityUserId,
                firstName: user.firstName,
                lastName: user.lastName, 
                address: user.address,
                email: user.email,
                userName: user.userName,
                teacherId: user.teacherId
            })
        }
    }, [user])

    useEffect(() => {
        getAndSetTeachers();
    }, [])

    const getAndSetTeachers = () => {
        getUsersWithRoles().then(data => {
          var filteredArr = data.filter(d => d.roles[0] == "Teacher");
          setTeachers(filteredArr);
        });
    }

    const toggleModal = () => {
        setModal(!modal)
    };

    const handleSubmit = async (e) => {
        e.preventDefault();
        await updateUserProfile(updatedUser);
        await getAndSetUser(user.id);
        toggleModal();
    }

    return (
    <div>
      <Button id="edit-profile-btn" className="create-btn" color='info' size='sm' onClick={toggleModal}>
        Edit Profile
      </Button>
      <Modal isOpen={modal} toggle={toggleModal} style={{color:'black'}} backdrop="static">
        <ModalHeader toggle={toggleModal}>
            Edit User Profile
        </ModalHeader>
        {loggedInUser?.roles[0] === "Teacher" || loggedInUser.id === user.id
        ?    <ModalBody className='modal-body'>
            
                <label className='modal-label'>First
                    <input
                        required
                        id='first-name-input'
                        value={updatedUser.firstName}
                        type='text'
                        onChange={(e) => {
                            const copy = {...updatedUser}
                            copy.firstName = e.target.value
                            setUpdatedUser(copy);
                        }}
                    />
                </label>

                <label className='modal-label'>Last
                    <input
                        required
                        id='last-name-input'
                        value={updatedUser.lastName}
                        type='text'
                        onChange={(e) => {
                            const copy = {...updatedUser}
                            copy.lastName = e.target.value
                            setUpdatedUser(copy);
                        }}
                    />
                </label>

                <label className='modal-label'>Address
                    <input
                        required
                        id='address-input'
                        value={updatedUser.address}
                        type='text'
                        onChange={(e) => {
                            const copy = {...updatedUser}
                            copy.address = e.target.value
                            setUpdatedUser(copy);
                        }}
                    />
                </label>

                <label className='modal-label'>Email
                    <input
                        required
                        id='email-input'
                        value={updatedUser.email}
                        type='email'
                        onChange={(e) => {
                            const copy = {...updatedUser}
                            copy.email = e.target.value
                            setUpdatedUser(copy);
                        }}
                    />
                </label>

                <label className='modal-label'>Username
                    <input
                        required
                        id='username-input'
                        value={updatedUser.userName}
                        type='text'
                        onChange={(e) => {
                            const copy = {...updatedUser}
                            copy.userName = e.target.value
                            setUpdatedUser(copy);
                        }}
                    />
                </label>

                {user.teacherId === null ? 
                <label className='modal-label'>Teacher
                    <select 
                        className='modal-select' 
                        defaultValue={updatedUser.teacherId}
                        onChange={(e) => {
                            const copy = {...updatedUser}
                            copy.teacherId = e.target.value * 1
                            setUpdatedUser(copy);
                        }}
                    >
                        <option>Select</option>
                        {teachers.map(t => <option key={t.id} value={t.id}>{t.firstName} {t.lastName}</option>)}
                    </select>
                </label>
                : null}

            </ModalBody>
            : 
                <ModalBody className='modal-body'>
                    <h4>Not Authorized to edit this user</h4>
                </ModalBody>
            }
            <ModalFooter>
                {updatedUser.firstName &&
                updatedUser.lastName &&
                updatedUser.email &&
                updatedUser.address &&
                updatedUser.userName &&
                updatedUser.identityUserId
                ?
                    <Button color="info" size='md' onClick={(e) => handleSubmit(e)}>
                        Update Profile
                    </Button> 
                : null}
            </ModalFooter>
      </Modal>
    </div>
  );
}